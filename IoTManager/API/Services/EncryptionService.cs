using System;
using System.Security.Cryptography;
using System.Text;

namespace IoTManager.API.Services
{
    public class EncryptionService
    {
        public static String Encrypt(String str)
        {
            String hash = GetMd5Hash(str);
            return hash;
        }

        public static bool Verify(String source, String hash)
        {
            if (GetMd5Hash(source) == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static String GetMd5Hash(String str)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.Default.GetBytes(str);
            byte[] data = md5Hasher.ComputeHash(inputBytes);
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                strBuilder.Append(data[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}