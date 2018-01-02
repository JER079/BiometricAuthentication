using System;
using System.Linq;

namespace BiometricAuthentication.Business
{
    //adapted from https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
    public class EncryptionKeyGenerator
    {
        private const int KeyLength = 64;

        private Random random = new Random();
        public string CreateNewEncrytionKey()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, KeyLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
