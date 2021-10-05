using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Cifrado
{
   public interface CYPHER<T>
    {
        string Cifrar(string code, T key);
        string Descifrar(string decode, T key);
    }

    public class Cesar: CYPHER<string>
    {

        public string Cifrar(string code, string key)
        {
            string clave = key;
            Dictionary<int, char> cipher = new Dictionary<int, char>();
            //nuevo abecedario
            for (int i = 0; i < clave.Length; i++)
            {
                cipher.Add(i, clave[i]);
            }
            for (int i = 0; i < 256; i++)
            {
                if (!cipher.ContainsValue(Convert.ToChar(i)))
                {
                    cipher.Add(cipher.Count, Convert.ToChar(i));
                }
            }
            //cifrado
            string cifrado = "";
            foreach (char l in cifrar)
            {
                cifrado += cipher[Convert.ToInt32(l)];
            }
            return cifrado;
        }
        public string Descifrar(string decode, string key)
        {
            Dictionary<char, int> cipher = new Dictionary<char, int>();
            //nuevo abecedario
            for (int i = 0; i < clave.Length; i++)
            {
                cipher.Add( clave[i], i);
            }
            for (int i = 0; i < 256; i++)
            {
                if (!cipher.ContainsKey(Convert.ToChar(i)))
                {
                    cipher.Add(Convert.ToChar(i), cipher.Count);
                }
            }
            //descifrado
            string descifrado = "";
            foreach(char l in cifrado)
            {
                descifrado += Convert.ToChar(cipher[l]);
            }

            return descifrado;
        }
    }

    public class ZigZag: CYPHER<int>
    {
        public string Cifrar(string code, int key)
        {
            string cifrado = "";

            return cifrado;
        }
        public string Descifrar(string decode, int key)
        {
            string descifrado = "";

            return descifrado;
        }
    }
}
