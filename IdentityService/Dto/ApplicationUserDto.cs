namespace IdentityService.Dto
{
    public class ApplicationUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public bool Banned { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public ApplicationUserDto() { }
    }
}
