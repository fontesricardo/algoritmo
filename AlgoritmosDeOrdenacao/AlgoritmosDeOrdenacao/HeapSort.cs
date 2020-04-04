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
            var numerosDesordenados = new List<int> { 10, 3, 9, 1, 7, 8, 2, 6, 4, 5 };

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var numero in numerosDesordenados)
            {
                AdicionarNaHeap(numero);
            }

            var numerosOrdenados1 = OrdenarPrimeiraVersao();

            stopwatch.Stop();
            Console.WriteLine($"{nameof(HeapSort)}.{nameof(OrdenarPrimeiraVersao)} => Fim {stopwatch.Elapsed}");
        }

        private IEnumerable<int> OrdenarPrimeiraVersao()
        {
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

        private int RetirarDaHeap()
        {
            return _heap[0];
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
    }
}
