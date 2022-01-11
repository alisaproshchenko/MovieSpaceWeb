using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public interface IPasswordValidator
    {
        public IEnumerable<string> Validate(string password);
    }
}
