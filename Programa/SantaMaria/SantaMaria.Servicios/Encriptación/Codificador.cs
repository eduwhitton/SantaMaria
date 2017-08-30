using System;
using System.IO;
using System.Security.Cryptography;

namespace SantaMaria.Servicios.Encriptacion
{
    /// <summary>
    /// Clase encargada de encriptar, desencriptar, y hashear.
    /// </summary>
    public class Codificador
    {
        private static Byte[] Key = System.Text.Encoding.Unicode.GetBytes("E8PHGQ7QOXBEORS2");
        private static Byte[] Iv = System.Text.Encoding.Unicode.GetBytes("RQNQRZYI");
        public static string Encriptar(string texto)
        {
            // Check arguments.
            if (texto == null || texto.Length <= 0)
                throw new ArgumentNullException("texto");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = Iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(
csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(texto);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);

        }

        public static string Desencriptar(string codigo)
        {
            // Check arguments.
            if (codigo == null || codigo.Length <= 0)
                throw new ArgumentNullException("codigo");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = Iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(codigo)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(
csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
        public static string Hash(string codigo)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new System.Text.UnicodeEncoding()).GetBytes(codigo);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
    }
}