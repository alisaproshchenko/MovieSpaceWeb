﻿namespace IdentityService.Dto
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public bool Banned { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
