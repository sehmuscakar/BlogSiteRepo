using DataAccess.Concrete.EntityFramework.Context;
using Business.DependencyResolvers;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;  // Business katmanýný referans et
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjeContext>();
builder.Services.MyconfigureServices(); // Burada çaðýrýyoruz

builder.Services.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<ProjeContext>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);//hangi tablolarý özeleþtirmiþsen onlarý buraya tanýman lazým ýdentitye ile sisteme önemli 
//þifre sýfýrlamada kullandýðýmýz için token buraya da ekiyoruz identityinin içine gerekli olaný 
builder.Services.AddMvc(config =>//bu tüm sistemi kilitliyor kimlik doðrulama oladan açýlmaz eriþilemez
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => //otonatike olmayan kýsmý buraya yunlendirecek bunu yapmadan da  [AllowAnonymous] bu kodu controllera yazarak ta yapabilirsin 
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();
