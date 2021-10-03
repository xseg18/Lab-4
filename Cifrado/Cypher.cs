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
