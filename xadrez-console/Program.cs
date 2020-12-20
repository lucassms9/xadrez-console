using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.Write("origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        bool[,] posicoesPosiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPosiveis);

                        Console.WriteLine("");
                        Console.Write("destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partida);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
