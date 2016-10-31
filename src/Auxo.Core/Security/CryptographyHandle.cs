using System.Collections.Generic;
using Auxo.Models;
using Auxo.Security;

namespace Auxo.Core.Security
{
    public static class CryptographyHandle
    {
        private static readonly IDictionary<string, ICryptography> _crypts  = new Dictionary<string, ICryptography> {
            { "PBKDF2", new PBKDF2() }
        };
        public static ICryptography Get(string alg) => _crypts[alg];
        public static ICryptography Cryptography(this Secure secure) => Get(secure.Algorithm);
    }
}