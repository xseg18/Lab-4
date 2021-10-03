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
        string Cifrar(string original);
        string Descifrar(string cifrado);
    }

    public class Cesar: CYPHER
    {
        string clave = "%12([centrifugados CENTRIFUGADOS])34$";
        Dictionary<char, int> cipher = new Dictionary<char, int>();
        Dictionary<int, char> abc = new Dictionary<int, char>();
        public string Cifrar(string cifrar)
        {
            //diccionario normal
            for (int i = 0; i < 256; i++)
            {
                abc.Add(i, Convert.ToChar(i));
            }
            //nuevo abecedario
            for (int i = 0; i < clave.Length; i++)
            {
                cipher.Add(clave[i], i);
            }
            for (int i = 0; i < 256; i++)
            {
                if (!cipher.ContainsKey(abc[i]))
                {
                    cipher.Add(abc[i], cipher.Count);
                }
            }
            //cifrado
            string cifrado = "";
            foreach(char l in cifrar)
            {
                cifrado += cipher[abc[Convert.ToInt32(l)]];
            }
            return cifrado;
        }
        public string Descifrar(string cifrado)
        {
            string descifrado = "";

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
