using System;
using Cifrado;

namespace Parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte code = Convert.ToByte(290);
            Cifrado.RSA rsa = new RSA();
            var llaves = rsa.generarLlaves(23, 13);
            int n = llaves.n;
            int e = llaves.e;
            int d = llaves.d;
        }
    }
}