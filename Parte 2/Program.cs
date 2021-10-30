using System;
using Cifrado;

namespace Parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte code = 102;
            Cifrado.RSA rsa = new RSA();
            var llaves = rsa.generarLlaves(23, 13);
            int n = llaves.Item1;
            int e = llaves.Item2;
            int d = llaves.Item3;
            byte cifrar = rsa.Cifer(code, n, e);
            byte descifrar = rsa.Cifer(cifrar, n, d);
        }
    }
}
