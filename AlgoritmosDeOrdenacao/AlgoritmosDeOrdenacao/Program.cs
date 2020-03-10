using System;
using System.Collections.Generic;

namespace AlgoritmosDeOrdenacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var numerosDesordenados = new List<int> { 5, 9, 3, 1, 2, 8, 4, 7, 6 };

            var numerosOrdenados1 = new BubbleSort().OrdenarDoInicioAoFim(numerosDesordenados);

            var numerosOrdenados2 = new BubbleSort().OrdenarDoInicioAoFim(numerosDesordenados);

            var numerosOrdenados3 = new BubbleSort().OrdenarDoInicioAoFim(numerosDesordenados);

            Console.WriteLine("Lista ordenada 1");
            foreach (var numero in numerosOrdenados1)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("Lista ordenada 2");
            foreach (var numero in numerosOrdenados2)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("Lista ordenada 3");
            foreach (var numero in numerosOrdenados3)
            {
                Console.WriteLine(numero);
            }

            Console.ReadLine();
        }
    }
}
