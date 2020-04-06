using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoritmosDeOrdenacao
{
    public class HeapSort
    {
        private IList<int> _heap;

        public HeapSort()
        {
            _heap = new List<int>();
        }

        public void Executar()
        {
            var numerosDesordenados = new List<int> { 74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11 };

            var numerosOrdenados1 = OrdenarPrimeiraVersao(numerosDesordenados);

            var numerosOrdenados2 = Ordenar(numerosDesordenados.ToArray());
        }

        private IEnumerable<int> OrdenarPrimeiraVersao(IEnumerable<int> numerosDesordenados)
        {
            foreach (var numero in numerosDesordenados)
            {
                AdicionarNaHeap(numero);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var ultimaPosicaoNaoValidada = _heap.Count - 1;

            while (ultimaPosicaoNaoValidada > 0)
            {
                var posicaoASerValidada = 0;

                var numero = _heap[ultimaPosicaoNaoValidada];

                _heap[ultimaPosicaoNaoValidada] = _heap[posicaoASerValidada];

                _heap[posicaoASerValidada] = numero;

                ultimaPosicaoNaoValidada--;

                var posicaoNumeroAEsquerda = PosicaoFilhoAEsquerda(posicaoASerValidada);
                var posicaoNumeroADireita = PosicaoFihoADireita(posicaoASerValidada);

                while (posicaoNumeroAEsquerda <= ultimaPosicaoNaoValidada)
                {
                    if (posicaoNumeroADireita <= ultimaPosicaoNaoValidada &&
                        _heap[posicaoNumeroADireita] > _heap[posicaoNumeroAEsquerda] &&
                        _heap[posicaoNumeroADireita] > _heap[posicaoASerValidada])
                    {
                        var trocarDePosicao = _heap[posicaoASerValidada];
                        _heap[posicaoASerValidada] = _heap[posicaoNumeroADireita];
                        _heap[posicaoNumeroADireita] = trocarDePosicao;
                        posicaoASerValidada = posicaoNumeroADireita;

                        posicaoNumeroAEsquerda = PosicaoFilhoAEsquerda(posicaoASerValidada);
                        posicaoNumeroADireita = PosicaoFihoADireita(posicaoASerValidada);

                        continue;
                    }

                    if (_heap[posicaoNumeroAEsquerda] > _heap[posicaoASerValidada])
                    {
                        var trocarDePosicao = _heap[posicaoASerValidada];
                        _heap[posicaoASerValidada] = _heap[posicaoNumeroAEsquerda];
                        _heap[posicaoNumeroAEsquerda] = trocarDePosicao;
                        posicaoASerValidada = posicaoNumeroAEsquerda;

                        posicaoNumeroAEsquerda = PosicaoFilhoAEsquerda(posicaoASerValidada);
                        posicaoNumeroADireita = PosicaoFihoADireita(posicaoASerValidada);

                        continue;
                    }

                    break;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"{nameof(HeapSort)}.{nameof(OrdenarPrimeiraVersao)} => Fim {stopwatch.Elapsed}");

            return _heap;
        }

        private void AdicionarNaHeap(int novoNumero)
        {
            _heap.Add(novoNumero);

            if (_heap.Count == 1)
                return;

            var posicaoDoNovoNumero = _heap.Count - 1;

            var posicaoDoPai = PosicaoDoPai(posicaoDoNovoNumero);

            while (posicaoDoPai >= 0 && _heap[posicaoDoNovoNumero] > _heap[posicaoDoPai])
            {
                var numero = _heap[posicaoDoPai];
                _heap[posicaoDoPai] = _heap[posicaoDoNovoNumero];
                _heap[posicaoDoNovoNumero] = numero;

                posicaoDoNovoNumero = posicaoDoPai;
                posicaoDoPai = PosicaoDoPai(posicaoDoNovoNumero);
            }
        }

        private int PosicaoDoPai(int posicaoFilho)
        {
            if (posicaoFilho % 2 == 0)
                return (posicaoFilho - 2) / 2;
            else
                return (posicaoFilho - 1) / 2;
        }

        private int PosicaoFilhoAEsquerda(int posicaoPai)
        {
            return 2 * posicaoPai + 1;
        }

        private int PosicaoFihoADireita(int posicaoPai)
        {
            return 2 * posicaoPai + 2;
        }
        
        private int[] Ordenar(int[] array)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, length, i);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }

            stopwatch.Stop();
            Console.WriteLine($"{nameof(HeapSort)}.{nameof(Ordenar)} => Fim {stopwatch.Elapsed}");

            return array;
        }

        private void Heapify(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, length, largest);
            }
        }
    }
}
