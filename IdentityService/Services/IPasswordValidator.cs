using System.Collections.Generic;

namespace IdentityService.Services
{
    public interface IPasswordValidator
    {
        public IEnumerable<string> Validate(string password);
    }
}
