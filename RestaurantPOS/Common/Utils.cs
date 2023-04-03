using BC = BCrypt.Net.BCrypt;
namespace RestaurantPOS.Common
{
    public class Utils
    {
        public static string HashPasswords(string pwd)
        {
            string pwdHash = BC.HashPassword(pwd);
            return pwdHash;
        }

        public static string HashString(string text, string secret)
        {
            string pwdHash = BC.HashPassword(text, secret);
            return pwdHash;
        }
        public static bool CheckHashPwd(string input, string hashPwd)
        {
            bool verified = BC.Verify(input, hashPwd);
            return verified;
        }
    }
}
