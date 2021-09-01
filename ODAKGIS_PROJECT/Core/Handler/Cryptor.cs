using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Core.Handler
{
    public static class Cryptor
    {
        private const string IV = "2wDwCbJtSVuTlXhL";
        private const string KEY = "OZMd2MfM6YuoFNLXM50FpJdjX0R926GF";
        public static string Sifrele(this string data)
        {
            byte[] buffer = null;

            Aes aes = Aes.Create();
            aes.IV = Encoding.UTF8.GetBytes(IV);
            aes.Key = Encoding.UTF8.GetBytes(KEY);

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                }
                buffer = ms.ToArray();
            }
            return Convert.ToBase64String(buffer);
        }

        public static string SifreCoz(this string data)
        {
            data = data.Replace('-', '+').Replace('_', '/').PadRight(4 * ((data.Length + 3) / 4), '=');
            byte[] buffer = Convert.FromBase64String(data);
            string result = null;

            Aes aes = Aes.Create();
            aes.IV = Encoding.UTF8.GetBytes(IV);
            aes.Key = Encoding.UTF8.GetBytes(KEY);

            ICryptoTransform encryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            return result;
        }

        public static string MD5Sifrele(string sifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        private static Random random = new Random();
        public static string KodUret(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
             .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
