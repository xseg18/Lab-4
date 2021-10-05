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
            string x = Cifrador.Descifrar(Cifrador.Cifrar("ESPACIO SIDERAL", 5), 5);
        }
    }
}
