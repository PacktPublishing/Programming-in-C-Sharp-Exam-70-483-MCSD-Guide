using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to start execution.");
            System.Console.ReadKey();

            #region symmetric Encryption
            Console.WriteLine("Using AES symmetric Algorithm");
            SymmetricAlgorithm sem = new AesManaged();
            Console.WriteLine("Encrypting data from inputfile");
            EncryptDecryptHelper.EncryptSymmetric(sem);
            Console.WriteLine("Data Encrypted. You can check in outputfile. Press any key to decrypt message");
            System.Console.ReadKey();
            Console.WriteLine("Decrypting content form outputfile");
            string message = EncryptDecryptHelper.DecryptSymmetric(sem);
            Console.WriteLine($"Decrypted data : {message}");
            #endregion

            #region asymmetric Encryption
            Console.WriteLine("Using asymmetric Algorithm");
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKey = rsa.ToXmlString(false);
            string pricateKey = rsa.ToXmlString(true);
            Console.WriteLine("Encrypting data ");
            byte[] resultbytes = EncryptDecryptHelper.EncryptAsymmetric(publicKey, "This is a dummy text to encrypt");
            Console.WriteLine("Data Encrypted. Press any key to decrypt message");
            System.Console.ReadKey();
            Console.WriteLine("Decrypting content");
            string resultText = EncryptDecryptHelper.DecryptAsymmetric(pricateKey, resultbytes);
            Console.WriteLine($"Decrypted data : {resultText}");
            #endregion

            #region Digital Signatures
            RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider();
            string publicKey1 = rsa1.ToXmlString(false);
            string pricateKey1 = rsa1.ToXmlString(true);
            EncryptDecryptHelper.DigitalSignatureSample(pricateKey1, publicKey1, "This is a sample text for Digital signatures");
            #endregion

            #region Hashvalue
            EncryptDecryptHelper.HashvalueSample("This a sample text for hashvalue sample");
            #endregion


            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
