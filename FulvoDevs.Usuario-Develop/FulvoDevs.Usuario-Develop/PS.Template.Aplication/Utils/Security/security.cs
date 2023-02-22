using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections;
using System.Security.Cryptography;

namespace PS.Template.Aplication.Security
{
    public class security
    {
        public ArrayList encryption(string Password)
        {

            byte[] salt;
            ArrayList array = new ArrayList();

            salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            array.Add(hashed);
            array.Add(salt);


            return array;
        }
    }
}
