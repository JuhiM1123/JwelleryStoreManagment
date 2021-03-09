using JwelleryStore.Common.Model;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JwelleryStore.Business.Encrption
{
    public class EncryptionManager : IEncryptionManager
    {
        private readonly AESConfig _aesConfig;

        public  EncryptionManager(AESConfig aesConfig)
        {
            _aesConfig = aesConfig;
        }

        public string EncryptAESPassword(string plainText)
        {
            return EncryptionHelper.EncryptAESPassword(plainText, _aesConfig.Key, _aesConfig.IV);
        }


        public string DecryptAESPassword(string cipherText)
        {          
            return EncryptionHelper.DecryptAESPassword(cipherText, _aesConfig.Key, _aesConfig.IV);     
        }

    }
}
