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
            Dictionary<int, char> cipher = new Dictionary<int, char>();
            //nuevo abecedario
            for (int i = 0; i < key.Length; i++)
            {
                if (!cipher.ContainsValue(key[i]))
                {
                    cipher.Add(cipher.Count, key[i]);
                }
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
            foreach (char l in code)
            {
                cifrado += cipher[Convert.ToInt32(l)];
            }
            return cifrado;
        }
        public string Descifrar(string decode, string key)
        {
            Dictionary<char, int> cipher = new Dictionary<char, int>();
            //nuevo abecedario
            for (int i = 0; i < key.Length; i++)
            {
                if (!cipher.ContainsValue(key[i]))
                {
                    cipher.Add(key[i], cipher.Count);
                }
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
            foreach(char l in decode)
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
            string cipher = "";
            int a = 0, b = 0;
            bool down = false;
            char[,] zigzag = new char[key, code.Length + 2 * key];
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
            int T = 1 + 1 + 2 * (key - 2);
            int C = decode.Length / T;
            List<string> zigzag = new List<string>();
            zigzag.Add(decode.Substring(0, C));
            decode = decode.Substring(C);
            zigzag.Add(decode.Substring(decode.Length - C));
            decode = decode.Substring(0, decode.Length - C);
            while (decode != "")
            {
                zigzag.Add(decode.Substring(0, C * 2));
                decode = decode.Substring(C * 2);
            }
            for (int i = 0; i < C; i++)
            {
                if (zigzag[0][i] != '▄')
                {
                    decipher += zigzag[0][i];
                }
                for (int j = 2; j < zigzag.Count(); j++)
                {
                    if (zigzag[j][2 * i] != '▄')
                    {
                        decipher += zigzag[j][2 * i];
                    }
                }
                if (zigzag[1][i] != '▄')
                {
                    decipher += zigzag[1][i];
                }
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
