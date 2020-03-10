using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmosDeOrdenacao
{
    public class BubbleSort
    {
        public IEnumerable<int> OrdenarPrimeiraVersao(IList<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            var posicaoJaOrdenada = 0;
            for (int i = numerosOrdenados.Count - 1; i > posicaoJaOrdenada; i--)
            {
                if (numerosOrdenados[i] < numerosOrdenados[i - 1])
                {
                    var posicaoA = numerosOrdenados[i];
                    var posicaoB = numerosOrdenados[i - 1];

                    numerosOrdenados[i] = posicaoB;
                    numerosOrdenados[i - 1] = posicaoA;
                }
                if (i == posicaoJaOrdenada + 1)
                {
                    posicaoJaOrdenada++;
                    i = numerosOrdenados.Count;
                }
            }

            return numerosOrdenados;
        }

        public IEnumerable<int> OrdenarDoFimAoInicio(IList<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            var moverNumero = 0;
            var descontarPosicao = 1;

            for (int write = 0; write < numerosOrdenados.Count; write++)
            {
                for (int sort = numerosOrdenados.Count - 1; sort > descontarPosicao - 1; sort--)
                {
                    if (numerosOrdenados[sort] < numerosOrdenados[sort - 1])
                    {
                        moverNumero = numerosOrdenados[sort - 1];
                        numerosOrdenados[sort - 1] = numerosOrdenados[sort];
                        numerosOrdenados[sort] = moverNumero;
                    }
                }
                descontarPosicao++;
            }

            return numerosOrdenados;
        }

        public IEnumerable<int> OrdenarDoInicioAoFim(IList<int> numerosDesordenados)
        {
            var numerosOrdenados = numerosDesordenados.ToList();

            var moverNumero = 0;
            var descontarPosicao = 1;

            for (int write = 0; write < numerosOrdenados.Count; write++)
            {
                for (int sort = 0; sort < numerosOrdenados.Count - descontarPosicao; sort++)
                {
                    if (numerosOrdenados[sort] > numerosOrdenados[sort + 1])
                    {
                        moverNumero = numerosOrdenados[sort + 1];
                        numerosOrdenados[sort + 1] = numerosOrdenados[sort];
                        numerosOrdenados[sort] = moverNumero;
                    }
                }
                descontarPosicao++;
            }

            return numerosOrdenados;
        }
    }
}
