using System.Security.Cryptography;
using System.Text;

namespace Back.Utils
{
    public static class PasswordHasher
    {
        public static string Hash(string entrada)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(entrada);
                var hashbytes = sHA256.ComputeHash(bytes);
                return Convert.ToHexString(hashbytes);
            }
        }
    }
}
