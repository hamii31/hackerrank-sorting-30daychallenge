using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AESCrypting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give pass:");
            var password = Console.ReadLine();
            Console.WriteLine("Text to encrypt");
            var text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            using (SymmetricAlgorithm crypt = Aes.Create())
            using (HashAlgorithm hash = MD5.Create())
            using (MemoryStream memorystream = new MemoryStream())
            {
                crypt.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                crypt.GenerateIV();
                using (CryptoStream cryptoStream = new CryptoStream(
            memorystream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(buffer, 0, buffer.Length);
                }

                string base64IV = Convert.ToBase64String(crypt.IV);
                string base64Ciphertext = Convert.ToBase64String(memorystream.ToArray());

                Console.WriteLine(base64IV + "!" + base64Ciphertext);
                var deciphered = Decrypt(base64Ciphertext, crypt.Key, crypt.IV);
                Console.WriteLine(deciphered);
            }
        }

        static string Decrypt(string base64Ciphertext, byte[] key, byte[] iV)
        {
            var plaintext = string.Empty;
            var base64Decipheredtext = Convert.FromBase64String(base64Ciphertext);
            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = iV;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var msDecrypt = new MemoryStream(base64Decipheredtext))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
