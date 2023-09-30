using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Helper
{
    public static class PasswordHasher
    {
        private const int SaltSize = 32;
        public static byte[] GenerateSalt()
        {
            var randomNumber = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return randomNumber;
        }

        public static byte[] ComputeHMAC_SHA256(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}
