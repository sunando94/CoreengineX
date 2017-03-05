using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreenginex.Models
{
    public class TokenProviderOption
    {
        public string Path { get; set; } = "/Token";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(15);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
