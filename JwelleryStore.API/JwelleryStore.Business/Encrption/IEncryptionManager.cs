using System;
using System.Collections.Generic;
using System.Text;

namespace JwelleryStore.Business.Encrption
{
    public interface IEncryptionManager
    {
        string EncryptAESPassword(string plainText);
        string DecryptAESPassword(string cipherText);
       
    }
}
