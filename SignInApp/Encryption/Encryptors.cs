using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SignInApp.Encryption
{
    class Encryptors
    {

        public static Aes LoadKey(string keyPath, string vectorPath)
        {
            Aes myAes = Aes.Create();

            using (FileStream keyStream = File.OpenRead(keyPath))
            {
                myAes.Key = ReadAllBytes(keyStream);
            }

            using (FileStream vectorStream = File.OpenRead(vectorPath))
            {
                myAes.IV = ReadAllBytes(vectorStream);
            }

            return myAes;
        }

        public static Aes LoadKey(string keyPath)
        {
            Aes myAes = Aes.Create();

            using (FileStream keyStream = File.OpenRead(keyPath))
            {
                myAes.Key = ReadAllBytes(keyStream);
            }

            return myAes;
        }

        public static byte[] KeyGenFromPassword(string password)
        {
            Rfc2898DeriveBytes derived = new Rfc2898DeriveBytes(password, EncryptionConstants.PASSWORD_SALT, EncryptionConstants.HASH_REPITIONS);
            return derived.GetBytes(EncryptionConstants.KEY_LENGTH);
        }

        public static Aes LoadKeyFromPassword(string password)
        {
            Aes myAes = Aes.Create();
            myAes.Key = KeyGenFromPassword(password);
            return myAes;
        }

        public static Aes LoadPasswordKey()
        {
            Aes myAes = Aes.Create();
            myAes.Key = EncryptionConstants.PASSWORD_KEY;
            return myAes;
        }

        public static byte[] ReadAllBytes(Stream fsSource)
        {
            // Read the source file into a byte array.
            byte[] bytes = new byte[fsSource.Length];
            int numBytesToRead = (int)fsSource.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                // Break when the end of the file is reached.
                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            return bytes;
        }

        public static void GenerateKey()
        {
            using (Aes myAes = Aes.Create())
            {
                using (FileStream keyStream = File.Create("encryption\\encryptionkey"))
                {
                    keyStream.Write(myAes.Key, 0, myAes.Key.Length);
                }

                using (FileStream vectorStream = File.Create("encryption\\encryptionvector"))
                {
                    vectorStream.Write(myAes.IV, 0, myAes.IV.Length);
                }

            }
        }

        public static byte[] AESEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
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

        public static string AESDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static string SaltAndHashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[EncryptionConstants.SALT_LENGTH]);

            var hash = new Rfc2898DeriveBytes(password, salt, EncryptionConstants.HASH_REPITIONS);
            byte[] hashBytes = hash.GetBytes(EncryptionConstants.HASH_LENGTH);

            byte[] hashAndSaltBytes = new byte[EncryptionConstants.HASH_LENGTH + EncryptionConstants.SALT_LENGTH];
            Array.Copy(salt, 0, hashAndSaltBytes, 0, EncryptionConstants.SALT_LENGTH);
            Array.Copy(hashBytes, 0, hashAndSaltBytes, EncryptionConstants.SALT_LENGTH, EncryptionConstants.HASH_LENGTH);

            return Convert.ToBase64String(hashAndSaltBytes);
        }

        public static bool CompareHash(string plainText, string hash)
        {
            byte[] savedHashAndSalt = Convert.FromBase64String(hash);
            byte[] salt = new byte[EncryptionConstants.SALT_LENGTH];

            Array.Copy(savedHashAndSalt, 0, salt, 0, EncryptionConstants.SALT_LENGTH);

            var newHash = new Rfc2898DeriveBytes(plainText, salt, EncryptionConstants.HASH_REPITIONS);
            byte[] newHashBytes = newHash.GetBytes(EncryptionConstants.HASH_LENGTH);

            for (int i = 0; i < EncryptionConstants.HASH_LENGTH; i++)
            {
                if (savedHashAndSalt[i+ EncryptionConstants.SALT_LENGTH] != newHashBytes[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static byte[] EncryptAndStoreIV(string plainText, byte[] Key)
        {
            return EncryptAndStoreIV(plainText, Key, Aes.Create().IV);
        }

        public static byte[] EncryptAndStoreIV(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encryptedString = AESEncrypt(plainText, Key, IV);
            byte[] output = new byte[encryptedString.Length + IV.Length];
            Array.Copy(IV, output, IV.Length);
            Array.Copy(encryptedString, 0, output, IV.Length, encryptedString.Length);
            return output;
        }

        public static string DecryptWithStoredIV(byte[] cipherIV, byte[] Key, int IVLength)
        {
            byte[] IV = new byte[IVLength];
            byte[] cipherText = new byte[cipherIV.Length - IVLength];
            Array.Copy(cipherIV, IV, IVLength);
            Array.Copy(cipherIV, IVLength, cipherText, 0, (cipherIV.Length - IVLength));
            return AESDecrypt(cipherText, Key, IV);
        }
    }
}
