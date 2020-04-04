using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgoritmosDeOrdenacao
{
    public class InsertionSort
    {
        public void Executar()
        {
            var numerosDesordenados = new List<int> { 5, 9, 3, 1, 2, 8, 4, 7, 6 };

            var numerosOrdenados1 = Ordenar(numerosDesordenados);
        }

        private IEnumerable<int> Ordenar(IEnumerable<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numerosOrdenados.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (numerosOrdenados[j - 1] > numerosOrdenados[j])
                    {
                        var moverNumero = numerosOrdenados[j - 1];
                        numerosOrdenados[j - 1] = numerosOrdenados[j];
                        numerosOrdenados[j] = moverNumero;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"{nameof(InsertionSort)}.{nameof(Ordenar)} => Fim {stopwatch.Elapsed}");

            return numerosOrdenados;
        }
    }
}
