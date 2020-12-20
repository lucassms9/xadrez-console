﻿using System;
namespace tabuleiro
{
    public class Tabuleiro
    {
        public int linhas { get; private set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            Peca pecasHandle = pecas[pos.linha, pos.coluna];
            return pecasHandle;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (exitePeca(pos))
            {
                throw new TabuleiroException("ja existe uma peca nessa posicao");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;

            pecas[pos.linha, pos.coluna] = null;

            return aux;
        }

        public bool exitePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }

            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posicao invalida");
            }
        }
    }
}
