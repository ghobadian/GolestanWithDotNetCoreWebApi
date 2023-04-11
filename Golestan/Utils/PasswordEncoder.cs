using System.Security.Cryptography;
using System.Text;
using NuGet.Protocol;

namespace Golestan.Utils
{
    public static class PasswordEncoder
    {
        private static readonly MD5CryptoServiceProvider md5CryptoServiceProvider = new();
        public static string Encode(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            var tmpHash = md5CryptoServiceProvider.ComputeHash(data);
            return ByteArrayToString(tmpHash);
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
