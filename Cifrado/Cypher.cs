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
            string cipher = "";
            int a = 0, b = 0;
            bool down = false;
            char[,] zigzag = new char[key, code.Length + key];
            for (int i = 0; i < code.Length; i++)
            {
                if (a == 0 || a == key - 1)
                {
                    down = !down;
                }
                zigzag[a, b++] = code[i];
                a = down ? a + 1 : a - 1;
            }
            while (a != 0)
            {
                if (a == 0 || a == key - 1)
                {
                    down = !down;
                }
                zigzag[a, b++] = '▄';
                a = down ? a + 1 : a - 1;
            }
            foreach (var item in zigzag)
            {
                if (item != '\0')
                {
                    cipher += item;
                }
            }
            return cipher;
        }
        public string Descifrar(string decode, int key)
        {
            string decipher = "";
            int a = 0, b = 0;
            int T = 1 + 1 + 2 * (key - 2);
            int C = decode.Length / T;
            List<string> zigzag = new List<string>();
            zigzag.Add(decode.Substring(0, C));
            decode = decode.Substring(C);
            zigzag.Add(decode.Substring(decode.Length - C));
            decode = decode.Substring(0, decode.Length - C);
            while (decode != "")
            {
                zigzag.Add(decode.Substring(0, T / C));
                decode = decode.Substring(T / C);
            }
            for (int i = 0; i < C; i++)
            {
                decipher += zigzag[0][i];
                for (int j = 2; j < zigzag.Count(); j++)
                {
                    if (zigzag[j][2 * i] != '▄')
                    {
                        decipher += zigzag[j][2 * i];
                    }
                }
                decipher += zigzag[1][i];
                for (int j = zigzag.Count - 1; j >= 2; j--)
                {
                    if (zigzag[j][2 * i + 1] != '▄')
                    {
                        decipher += zigzag[j][2 * i + 1];
                    }
                }
            }
            return decipher;
        }
    }
}
