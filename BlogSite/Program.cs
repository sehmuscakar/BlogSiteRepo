using DataAccess.Concrete.EntityFramework.Context;
using Business.DependencyResolvers;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;  // Business katmanını referans et
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ProjeContext>();
builder.Services.AddDbContext<ProjeContext>(opt => //contextteki constractýr sýkýntý yaratýðý için diðer yöntemi kullandým.
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.MyconfigureServices(); // Burada çağırıyoruz

builder.Services.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<ProjeContext>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);//hangi tabloları özeleştirmişsen onları buraya tanıman lazım ıdentitye ile sisteme önemli 
//şifre sıfırlamada kullandığımız için token buraya da ekiyoruz identityinin içine gerekli olanı 
builder.Services.AddMvc(config =>//bu tüm sistemi kilitliyor kimlik doğrulama oladan açılmaz erişilemez
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => //otonatike olmayan kısmı buraya yunlendirecek bunu yapmadan da  [AllowAnonymous] bu kodu controllera yazarak ta yapabilirsin 
{
    x.LoginPath = "/Admin/Login/SignIn";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // UseAuthorization'dan önce olmalı  // middleweiv // sunucuda bu olmazsa post hataı alrısın sürekli 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();
