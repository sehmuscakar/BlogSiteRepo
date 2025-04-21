namespace BlogSite.Areas.Admin.Models
{
    public class AppUserEditModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
