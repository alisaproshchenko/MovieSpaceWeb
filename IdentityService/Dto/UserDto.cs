﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Dto
{
    class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Banned { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
