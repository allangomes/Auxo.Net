using System;
using System.Security.Cryptography;
using Auxo.Models;

namespace Auxo.Security
{
    public class PBKDF2 : ICryptography
    {
        public const int SALT_BYTES = 32;
        public const int HASH_BYTES = 32;
        public const int ITERATIONS = 64000;

        public static byte[] CreateSalt(int saltBits)
        {
            byte[] salt = new byte[saltBits];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            return salt;
        }

        public static byte[] CreateHash(string value, byte[] salt, int iterations, int hashBits)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(value, salt, iterations))
                return pbkdf2.GetBytes(hashBits);
        }

        public static Secure Encrypt(string value)
        {
            var salt = CreateSalt(SALT_BYTES);
            var hash = CreateHash(value, salt, ITERATIONS, HASH_BYTES);
            return new Secure(
                algorithm: nameof(PBKDF2),
                parameters: ITERATIONS.ToString(),
                salt: Convert.ToBase64String(salt),
                hash: Convert.ToBase64String(hash)
            );
        }

        public static bool SlowEquals(byte[] a, byte[] b)
        {
            int diff = a.Length ^ b.Length;
            for(int i = 0; i < a.Length && i < b.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        public string Decrypt(Secure value)
        {
            throw new NotImplementedException();
        }

        public bool Same(Secure security, string value)
        {
            var hashBytes = Convert.FromBase64String(security.Hash);
            var hashTest = CreateHash(value, Convert.FromBase64String(security.Salt), int.Parse(security.Parameters), hashBytes.Length);
            return SlowEquals(hashBytes, hashTest);
        }
    }
}