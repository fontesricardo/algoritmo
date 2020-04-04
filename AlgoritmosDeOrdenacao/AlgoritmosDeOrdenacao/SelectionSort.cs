using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgoritmosDeOrdenacao
{
    public class SelectionSort
    {
        public void Executar()
        {
            var numerosDesordenados = new List<int> { 5, 9, 3, 1, 2, 8, 4, 7, 6 };

            var numerosOrdenados1 = OrdenarPrimeiraVersao(numerosDesordenados);

            var numerosOrdenados2 = Ordenar(numerosDesordenados);
        }

        private IEnumerable<int> OrdenarPrimeiraVersao(IEnumerable<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            int posicaoMenorNumero;
            int trocarDePosicao;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numerosOrdenados.Count; i++)
            {
                posicaoMenorNumero = i;
                for (int j = i + 1; j < numerosOrdenados.Count; j++)
                {
                    if (numerosOrdenados[posicaoMenorNumero] > numerosOrdenados[j])
                        posicaoMenorNumero = j;
                }
                trocarDePosicao = numerosOrdenados[i];
                numerosOrdenados[i] = numerosOrdenados[posicaoMenorNumero];
                numerosOrdenados[posicaoMenorNumero] = trocarDePosicao;
            }

            stopwatch.Stop();
            Console.WriteLine($"{nameof(SelectionSort)}.{nameof(OrdenarPrimeiraVersao)} => Fim {stopwatch.Elapsed}");

            return numerosOrdenados;
        }

        private IEnumerable<int> Ordenar(IEnumerable<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            int totalNumeros = numerosOrdenados.Count;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < totalNumeros - 1; i++)
            {
                int posicaoMenorNumero = i;
                for (int j = i + 1; j < totalNumeros; j++)
                    if (numerosOrdenados[j] < numerosOrdenados[posicaoMenorNumero])
                        posicaoMenorNumero = j;

                int temp = numerosOrdenados[posicaoMenorNumero];
                numerosOrdenados[posicaoMenorNumero] = numerosOrdenados[i];
                numerosOrdenados[i] = temp;
            }

            stopwatch.Stop();
            Console.WriteLine($"{nameof(SelectionSort)}.{nameof(Ordenar)} => Fim {stopwatch.Elapsed}");

            return numerosOrdenados;
        }
    }
}
