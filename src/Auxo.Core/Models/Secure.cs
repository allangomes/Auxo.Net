using Auxo.Core.Security;

namespace Auxo.Models
{
    public class Secure : Entity
    {
        public string Algorithm { get; private set; }
        public string Hash { get; private set; }
        public string Salt { get; private set; }
        public string Parameters { get; private set; }

        private Secure()
        {
        }

        internal Secure(string algorithm, string hash, string salt, string parameters)
        {
            Algorithm = algorithm;
            Parameters = parameters;
            Salt = salt;
            Hash = hash;
        }

        public override bool Equals (object obj)
        {
            var crypt = this.Cryptography();
            return crypt.Same(this, obj.ToString());
        }
        
        public override int GetHashCode() => Hash.GetHashCode();

        public static bool operator ==(Secure security, string Value) => security.Equals(Value);

        public static bool operator !=(Secure security, string Value) => !security.Equals(Value);
    }
}