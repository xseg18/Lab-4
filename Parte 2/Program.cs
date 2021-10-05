using System;
using Cifrado;

namespace Parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CYPHER<string> Cifrador = new Cesar();
            string x = Cifrador.Descifrar(Cifrador.Cifrar("ESPACIO SIDERAL", "SECRETO"), "SECRETO");
        }
    }
}
