using System;
using Cifrado;

namespace Parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CYPHER<int> Cifrador = new ZigZag();
            string x = Cifrador.Descifrar(Cifrador.Cifrar("TENgo HambRe CoÑO", 5), 5);
        }
    }
}
