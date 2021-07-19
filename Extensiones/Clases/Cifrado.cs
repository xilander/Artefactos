using System;
using System.Security.Cryptography;
using System.Text;

namespace Extensiones.Clases
{
    public class Cifrado
    {
        //static string clave = "TG7pDQSRGk2cFwAqwVd43A%3d%3d";
        
        public static string Cifrar(string cadena, string claveCifrado = "TG7pDQSRGk2cFwAqwVd43A%3d%3d")
        {
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(claveCifrado));
            md5.Clear();

            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }

        public static string Descifrar(string cadena, string claveCifrado= "TG7pDQSRGk2cFwAqwVd43A%3d%3d")
        {
            try
            {
                byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.

                // Ciframos utilizando el Algoritmo MD5.
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(claveCifrado));
                md5.Clear();

                // Ciframos utilizando el Algoritmo 3DES.
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = llave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform convertir = tripledes.CreateDecryptor();

                byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
                tripledes.Clear();
                string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
                return cadena_descifrada; // Devolvemos la cadena
            }
            catch (Exception)
            {
                return ("La firma es erronea");
            }
        }

    }
}
