using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Numerics;

namespace Cifrado
{
   public interface CYPHER
   {
        byte Cifer(byte code, int key, int key2);
   }

    public class RSA : CYPHER
    {
        public byte Cifer(byte code, int n, int k)
        {
            var i = BigInteger.ModPow(code, k, n);
            byte x = (byte)i;
            return x;
        }
        
        public (int n, int e, int d) generarLlaves(int p, int q)
        {
            if(primo(p) && primo(q) && p <= 512 && q <= 512)
            {
                int n = p * q;
                int phi = (p - 1) * (q - 1);
                int e = 2;
                int alpha = 1;
                bool a = false;
                while (!a)
                {
                    while (e < phi)
                    {
                        if (primo(e) && MCD(e, phi) == 1)
                        {
                            break;
                        }
                        else
                        {
                            e++;    
                        }
                    }
                    alpha = phi - (phi / e) * e;
                    if(alpha != e - 1)
                    {
                        break;
                    }
                    else
                    {
                        e++;
                    }
                }
                int beta = phi - (phi / e) * 1;
                int theta = e - (e / alpha) * alpha;
                int lambda = 1 - (e / alpha) * beta;
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
                if ((primo % i) == 0)
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
