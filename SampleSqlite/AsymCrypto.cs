using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PCLCrypto.WinRTCrypto;

namespace SampleSqlite
{
    public class AsymCrypto
    {
       
        public static ICryptographicKey CreateKey()
        {

            var asym = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
            ICryptographicKey key = asym.CreateKeyPair(512);
            var publicKey = key.ExportPublicKey();
            return key;

        }
        public static byte[] EncryptRsa(string data)
        {
            var asym = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
            var publickey = App.Publickey;
            //ICryptographicKey key = asym.CreateKeyPair(512);
            
            var plain = Encoding.UTF8.GetBytes(data);
            var encrypted = CryptographicEngine.Encrypt(publickey, plain);
            return encrypted;
        }
        public static string DecryptRsa(byte[] data)
        {
            var asym = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
            var publickey = App.Publickey;
            //ICryptographicKey key = asym.CreateKeyPair(512);
            var decrypted = CryptographicEngine.Decrypt(publickey, data);
            var decrypt = Convert.ToBase64String(decrypted);
            return decrypt;
        }
    }
}
