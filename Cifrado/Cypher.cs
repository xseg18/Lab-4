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
            string cifrado = "";

            return cifrado;
        }
        public string Descifrar(string decode, string key)
        {
            string descifrado = "";

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
