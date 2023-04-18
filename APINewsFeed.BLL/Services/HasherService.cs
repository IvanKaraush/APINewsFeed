using APINewsFeed.BLL.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace APINewsFeed.BLL.Services
{
    public class HasherService : IHasher
    {
        public string GetHash(string password)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
               return Convert.ToHexString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
