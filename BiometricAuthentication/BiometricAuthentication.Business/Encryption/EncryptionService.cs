using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BiometricAuthentication.Business.Encryption
{
    // adapted from https://www.codeproject.com/Tips/839656/How-to-encrypt-and-decrypt-string-using-AES-algori
    public class EncryptionService
    {
        public string encrypt(string messageToEncrypt, string encryptionKey)
        { 
            byte[] clearBytes = Encoding.Unicode.GetBytes(messageToEncrypt);
            using (Aes encryptor = Aes.Create())
            {
                // the 0x49, 0x76 etc are in hex
                // pdb = program database
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]{
                            0x49,0x76,0x61,0x6e,0x20,0x4d,0x65,0x64,0x76,0x65,0x64,0x65,0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    messageToEncrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return messageToEncrypt;
        }
    }
}
