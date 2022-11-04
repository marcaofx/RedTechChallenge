using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RedTechnologies.Shared
{
    public static class Encrypt
    {
        public static string EncryptValue(string plainTextValue)
        {
            StringBuilder encryptedValue = new StringBuilder();
            MD5 hasher = MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(plainTextValue));

            foreach (byte t in data)
            {
                // The format string indicates "hexadecimal with a precision of two digits"
                // https://msdn.microsoft.com/en-us/library/dwhawy9k%28v=vs.110%29.aspx
                encryptedValue.Append(t.ToString("x2"));
            }

            return encryptedValue.ToString();
        }
    }
}
