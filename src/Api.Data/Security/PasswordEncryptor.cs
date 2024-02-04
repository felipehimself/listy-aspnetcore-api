using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace Api.Data.Security
{
    public class PasswordEncryptor
    {
        private const string Pepper = "YourPepperValue1234"; // Add a pepper value for additional security

        public static string Encrypt(string password)
        {
            // Generate a salt value
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Derive a key using PBKDF2
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password + Pepper,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Combine salt and hashed password
            string encryptedPassword = Convert.ToBase64String(salt) + ":" + hashedPassword;

            return encryptedPassword;
        }

        public static bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            // Extract salt and hashed password from the stored value
            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            string storedHashedPassword = parts[1];

            // Derive a key using PBKDF2 with the input password and stored salt
            string derivedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: inputPassword + Pepper,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Compare the derived password with the stored hashed password
            return derivedPassword == storedHashedPassword;
        }
    }
}