using System;
using Cifrado;
namespace Parte_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CYPHER Cifrador = new Cesar();
            string x = Cifrador.Descifrar(Cifrador.Cifrar("TENgo HambRe CoÑO"));
        }
    }
}
