using System;
using System.Collections.Generic;

namespace AlgoritmosDeOrdenacao
{
    class Program
    {
        static void Main(string[] args)
        {
            new InsertionSort().Executar();

            new BubbleSort().Executar();

            new SelectionSort().Executar();

            Console.Read();
        }
    }
}
