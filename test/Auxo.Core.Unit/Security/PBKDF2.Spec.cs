using System;
using Auxo.Core.Security;
using Auxo.Security;
using NUnit.Framework;

namespace Auxo.Core.Unit.Security
{
    [TestFixture]
    public class PBKDF2_CreateSalt
    {
        [TestCase(24)]
        [TestCase(32)]
        public void Expect_Salt_With_Size(int saltBits)
        {
            var salt = PBKDF2.CreateSalt(saltBits);
            Assert.AreEqual(saltBits, salt.Length);
        }
    }

    [TestFixture]
    public class PBKDF2_CreateHash
    {
        public void Expect_Equal()
        {
            var hash = Convert.FromBase64String("+WqsZSS2m8iId8QQAayiIS6bLUj4R/Caem72blANo20=");
            var salt = Convert.FromBase64String("fcOMenFOG3yx8khQ4m0MMAIhhHZ1qKLD4wH23CH8hCs=");

            var result = PBKDF2.CreateHash("echoes", salt, 64000, hash.Length);
            Assert.AreEqual(hash, result);
        }
    }

    [TestFixture]
    public class PBKDF2_Encrypt
    {
        public void Expect_Not_Equal()
        {
            var hash1 = PBKDF2.Encrypt("echoes");
            var hash2 = PBKDF2.Encrypt("echoes");
            Assert.AreNotEqual(hash1.Salt, hash2.Salt);
            Assert.AreNotEqual(hash1.Hash, hash2.Hash);
        }

        public void Expect_Equal()
        {
            var secure = PBKDF2.Encrypt("echoes");
            Assert.AreEqual("PBKDF2",  secure.Algorithm);
            Assert.AreEqual("64000",  secure.Parameters);
        }
    }

    [TestFixture]
    public class PBKDF2_SlowEquals
    {
        [TestCase(new byte[] { 255, 3 }, new byte[] { 255, 3}, true)]
        [TestCase(new byte[] { 236, 43 }, new byte[] { 236, 42}, false)]
        public void Check_Slow_Equals(byte[] a, byte[] b, bool result)
        {
            Assert.AreEqual(result, PBKDF2.SlowEquals(a, b));
        }
    }

    public class PBKDF2_Decrypt
    {
        public void Check()
        {
            var secure = PBKDF2.Encrypt("echoes"); 
            var crpt = new PBKDF2();
            Assert.Throws<NotImplementedException>(() => crpt.Decrypt(secure));
        }
    }

    public class PBKDF2_Same
    {
        public void Check()
        {
            var secure = PBKDF2.Encrypt("echoes"); 
            Assert.True(secure.Cryptography().Same(secure, "echoes"));
        }
    }
}