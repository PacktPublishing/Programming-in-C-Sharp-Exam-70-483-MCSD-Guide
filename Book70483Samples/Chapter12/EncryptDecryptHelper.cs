using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Chapter12
{
    internal class EncryptDecryptHelper
    {
        #region Symmetric Encryption
        public static void EncryptSymmetric(SymmetricAlgorithm sem)
        {
            //Read content from file
            string filecontent = File.ReadAllText("..\\..\\inputfile.txt");
            //Create encryptor using key and vector
            ICryptoTransform encryptor = sem.CreateEncryptor(sem.Key, sem.IV);
            //create memory stream used at runtime to store data
            using (MemoryStream outputstream = new MemoryStream())
            {
                //Create crypto stream in write mode
                using (CryptoStream encStream = new CryptoStream(outputstream, encryptor, CryptoStreamMode.Write))
                {
                    //use streamwrite  
                    using (StreamWriter writer = new StreamWriter(encStream))
                    {
                        // Write the text in the stream writer   
                        writer.Write(filecontent);
                    }
                }
                // Get the result as a byte array from the memory stream   
                byte[] encryptedDataFromMemory = outputstream.ToArray();
                // Write the data to a file   
                File.WriteAllBytes("..\\..\\Outputfile.txt", encryptedDataFromMemory);
            }
        }

        public static string DecryptSymmetric(SymmetricAlgorithm sem)
        {
            string result = string.Empty;
            //Create decryptor
            ICryptoTransform decryptor = sem.CreateDecryptor(sem.Key, sem.IV);
            //read file content
            byte[] filecontent = File.ReadAllBytes("..\\..\\Outputfile.txt");
            //read file content to memory stream
            using (MemoryStream outputstream = new MemoryStream(filecontent))
            {
                //create decrypt stream
                using (CryptoStream decryptStream = new CryptoStream(outputstream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(decryptStream))
                    {
                        //read content of stream till end
                        result = reader.ReadToEnd();
                    }
                }
            }
            return result;
            
        }
        #endregion

        #region Asymmetric Encryption
        public static byte[] EncryptAsymmetric(string publicKey, string texttoEncrypt)
        {
            byte[] result;
            UnicodeEncoding uc = new UnicodeEncoding();
            byte[] databytes = uc.GetBytes(texttoEncrypt);
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                result = rsa.Encrypt(databytes, true);
            }
            return result;
        }

        public static string DecryptAsymmetric(string privateKey, byte[] bytestoDecrypt)
        {
            byte[] result;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                result = rsa.Decrypt(bytestoDecrypt, true);
            }
            UnicodeEncoding uc = new UnicodeEncoding();
            string resultText = uc.GetString(result);
            return resultText;
        }
        #endregion

        #region DigitalSignatures
        public static void DigitalSignatureSample(string senderPrivatekey, string receirverspublickey, string texttoEncrypt)
        {
            UnicodeEncoding uc = new UnicodeEncoding();
            Console.WriteLine("Converting to bytes from text");
            byte[] databytes = uc.GetBytes(texttoEncrypt);
            Console.WriteLine("Creating crypoclass instance");
            RSACryptoServiceProvider rsasender = new RSACryptoServiceProvider();
            RSACryptoServiceProvider rsareceiver = new RSACryptoServiceProvider();
            rsasender.FromXmlString(senderPrivatekey);
            rsareceiver.FromXmlString(receirverspublickey);
            Console.WriteLine("Creating signature formatter instance");
            RSAPKCS1SignatureFormatter signatureFormatter = new RSAPKCS1SignatureFormatter(rsasender);
            signatureFormatter.SetHashAlgorithm("SHA1");
            Console.WriteLine("encrypting message");
            byte[] encryptedBytes = rsareceiver.Encrypt(databytes, false);
            byte[] computedhash = new SHA1Managed().ComputeHash(encryptedBytes);
            Console.WriteLine("Creating signature");
            byte[] signature = signatureFormatter.CreateSignature(computedhash);
            Console.WriteLine("Signature: " + Convert.ToBase64String(signature));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("recomputing hash");
            byte[] recomputedHash = new SHA1Managed().ComputeHash(encryptedBytes);
            Console.WriteLine("Creating signature dformatter instance");
            RSAPKCS1SignatureDeformatter signatureDFormatter = new RSAPKCS1SignatureDeformatter(rsareceiver);
            signatureDFormatter.SetHashAlgorithm("SHA1");
            Console.WriteLine("verifying signature");
            if (!signatureDFormatter.VerifySignature(recomputedHash, signature))
            {
                Console.WriteLine("Signature did not match from sender");
            }
            Console.WriteLine("decrypting message");
            byte[] decryptedText = rsasender.Decrypt(encryptedBytes, false);
            Console.WriteLine(Encoding.UTF8.GetString(decryptedText));
        }
        #endregion

        #region Hashvalues
        public static void HashvalueSample(string texttoEncrypt)
        {
            UnicodeEncoding uc = new UnicodeEncoding();
            Console.WriteLine("Converting to bytes from text");
            byte[] databytes = uc.GetBytes(texttoEncrypt);
            byte[] computedhash = new SHA1Managed().ComputeHash(databytes);
            foreach (byte b in computedhash)
            {
                Console.Write("{0} ", b);
            }
            Console.WriteLine("Press any key to continue...");
            byte[] reComputedhash = new SHA1Managed().ComputeHash(databytes);
            bool result = true;
            for (int x = 0; x < computedhash.Length; x++)
            {
                if (computedhash[x] != reComputedhash[x])
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }

            if (result)
            {
                Console.WriteLine("Hash value is same");
            }
            else
            {
                Console.WriteLine("Hash value is not same");
            }
        }
        #endregion
    }
}
