using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services.Security
{
    public class PasswordEncryptorService
    {

        public static string Encrypt(string password)
        {

            var pepper = Environment.GetEnvironmentVariable("Pepper");

            // Generate a salt value
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password + pepper,
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
            var pepper = Environment.GetEnvironmentVariable("Pepper");

            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            string storedHashedPassword = parts[1];


            string derivedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: inputPassword + pepper,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));


            return derivedPassword == storedHashedPassword;
        }
    }
}