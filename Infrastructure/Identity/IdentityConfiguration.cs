using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public sealed class IdentityConfiguration
    {
        /// <summary>
        /// Days before a forged token expires
        /// </summary>
        public int DaysBeforeExpiration { get; set; } = 1;

        /// <summary>
        /// Application's secret, used to encode the JWT
        /// </summary>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        /// Algorithm used to encode the JWT
        /// </summary>
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256;

        /// <summary>
        /// Audience for which the JWT is forged
        /// </summary>
        public string TokenAudience { get; set; } = "http://localhost";

        /// <summary>
        /// Issuer of the JWT
        /// </summary>
        public string TokenIssuer { get; set; } = "http://localhost";

        /// <summary>
        /// Whether or not the token audience should be using HTTPS
        /// </summary>
        public bool TokenRequireHttpsMetadata { get; set; } = true;

        /// <summary>
        /// Retrieve the <see cref="SymmetricSecurityKey"/> to be used to forge the JWT
        /// </summary>
        public SymmetricSecurityKey SecurityKey
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
    }
}
