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
        byte Cifrar(byte code, T key, T key2);
        byte Descifrar(byte decode, T key, T key2);
    }

    public class RSA : CYPHER<int>
    {
        public byte Cifrar(byte code, int key, int key2)
        {
            int n = generarLlaves(key, key2).Item1;
            int e = generarLlaves(key, key2).Item2;
            byte cipher = Convert.ToByte(Math.Pow(code, e) % n);
            return cipher;
        }
        public byte Descifrar(byte decode, int key, int key2)
        {
            int n = generarLlaves(key, key2).Item1;
            int d = generarLlaves(key, key2).Item3;
            byte decipher = Convert.ToByte(Math.Pow(decode, d) % n);
            return decipher;

        }
        (int, int, int) generarLlaves(int p, int q)
        {
            if(primo(p) && primo(q) && p <= 512 && q <= 512)
            {
                int n = p * q;
                int phi = (p - 1) * (q - 1);
                Random rand = new Random();
                int e = rand.Next(1, phi);
                int mcd = MCD(e, phi);
                while (mcd != 1)
                {
                    e = rand.Next(1, phi);
                    mcd = MCD(e, phi);
                }
                int alpha = phi - (phi / e) * e;
                int beta = phi - (phi / e) * mcd;
                int theta = e - (e / alpha) * alpha;
                int lambda = mcd - (e / alpha) * beta;
                while(lambda < 0)
                {
                    lambda += phi;
                }
                int d = beta - (alpha / theta) * lambda;
                return (n, e, d); 
            }
            else
            {
                throw new Exception();
            }
        }
        bool primo(int primo)
        {
            for (int i = 2; i < primo; i++)
            {
                if(i%2 == 0)
                {
                    return false;
                }
            }
            return true;
        }
        int MCD(int m, int n)
        {
            int a = Math.Max(m, n);
            int b = Math.Min(m, n);
            int mcd = 0;
            do
            {
                mcd = b;
                b = a % b;
                a = mcd;
            } while (b != 0);
            return mcd;
        }
    }
}
