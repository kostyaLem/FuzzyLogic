using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FuzzyLogic.DAL.Utils
{
    internal static class PasswordCreator
    {
        private readonly static byte[] _salt;

        static PasswordCreator()
        {
            var config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build();
            _salt = Convert.FromBase64String(config["PasswordSalt"]);
        }

        public static string CreateHash(string password)
        {
            var passwordBytes = Encoding.Unicode.GetBytes(password);
            var passwordBytesHash = GenerateSaltedHash(passwordBytes);

            return Encoding.Unicode.GetString(passwordBytesHash);
        }

        private static byte[] GenerateSaltedHash(byte[] plainText)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + _salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < _salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = _salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
