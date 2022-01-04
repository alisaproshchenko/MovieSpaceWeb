using System.Collections.Generic;

namespace Web.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public bool Banned { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}