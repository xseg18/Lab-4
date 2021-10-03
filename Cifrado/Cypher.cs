using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Cifrado
{
   public interface CYPHER
    {
        public string Cifrar(string original);
        public string Descifrar(string cifrado);
    }

    public class Cesar: CYPHER
    {
        string clave = "%12([centrifugados CENTRIFUGADOS])34$";
        public string Cifrar(string cifrar)
        {
            
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
        public string Descifrar(string cifrado)
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

    public class ZigZag: CYPHER
    {
        public string Cifrar(string cifrar)
        {
            string cifrado = "";

            return cifrado;
        }
        public string Descifrar(string cifrado)
        {
            string descifrado = "";

            return descifrado;
        }
    }
}
