using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmAppCookieAuth.Shared
{
    public class UserProfileDto
    {
        public string UserId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
