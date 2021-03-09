using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JwelleryStore.Business.Encrption
{
    public static class EncryptionHelper
    {
        public static string EncryptAESPassword(string plainText, string key, string iv)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var ivBytes = Encoding.UTF8.GetBytes(iv);
            var decriptedFromJavascript = EncryptStringToBytes(plainText, keyBytes, ivBytes);
            return Convert.ToBase64String(decriptedFromJavascript);
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a AesCryptoServiceProvider object
            // with the specified key and IV.
            using (var aesCrypto = new AesCryptoServiceProvider())
            {
                aesCrypto.Mode = CipherMode.CBC;
                aesCrypto.Padding = PaddingMode.PKCS7;
                aesCrypto.FeedbackSize = 128;

                aesCrypto.Key = key;
                aesCrypto.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = aesCrypto.CreateEncryptor(aesCrypto.Key, aesCrypto.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptAESPassword(string cipherText, string key, string iv)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var ivBytes = Encoding.UTF8.GetBytes(key);
            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keyBytes, ivBytes);
            return decriptedFromJavascript;
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (var aesCrypto = new AesCryptoServiceProvider())
            {
                //Settings
                aesCrypto.Mode = CipherMode.CBC;
                aesCrypto.Padding = PaddingMode.PKCS7;
                aesCrypto.FeedbackSize = 128;

                aesCrypto.Key = key;
                aesCrypto.IV = iv;

                // Create a decrytor to perform the stream transform.
                var decryptor = aesCrypto.CreateDecryptor(aesCrypto.Key, aesCrypto.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                   
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }
    }
}
