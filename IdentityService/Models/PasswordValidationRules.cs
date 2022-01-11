using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Models
{
    public class PasswordValidationRules
    {
        public int RequiredLength;
        public bool RequireNonLetterOrDigit;
        public bool RequireDigit;
        public bool RequireLowercase;
        public bool RequireUppercase;

        public PasswordValidationRules(int requiredLength = 6, bool requireNonLetterOrDigit = false, 
            bool requireDigit = true, bool requireLowercase = true, bool requireUppercase = true)
        {
            RequiredLength = requiredLength;
            RequireNonLetterOrDigit = requireNonLetterOrDigit;
            RequireDigit = requireDigit;
            RequireLowercase = requireLowercase;
            RequireUppercase = requireUppercase;
        }
    }
}
