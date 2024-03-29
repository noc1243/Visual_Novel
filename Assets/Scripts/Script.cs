﻿using System.Collections;
using System.Collections.Generic;

public class Script
{
    public string id;
    public string texto;
    public string background;
    public string musica;
    public string efeito;
    public string personagens;
    public string [] escolha;
    public string [] rota;
    public string gameOver;
    public string personagemDireita;
    public string apareceDireita;
    public string personagemEsquerda;
    public string apareceEsquerda;
    public string musicaASerDestruida;
    public string puloDeCena;


    public Script (string id, string texto, string background, string musica, string efeito, string personagens, string escolha1, string escolha2, string escolha3, string rota1, string rota2, string rota3, string gameOver, string personagemDireita, string apareceDireita, string personagemEsquerda, string apareceEsquerda, string musicaASerDestruida, string puloDeCena) {
        escolha = new string [3];
        rota = new string [3];


        this.id = id;
        this.texto = texto.Trim();
        this.background = background.Trim();
        this.musica = musica.Trim();
        this.efeito = efeito.Trim();
        this.personagens = personagens.Trim();
        this.escolha [0] = escolha1.Trim();
        this.escolha [1] = escolha2.Trim();
        this.escolha [2] = escolha3.Trim();
        this.rota [0] = rota1.Trim();
        this.rota [1] = rota2.Trim();
        this.rota [2] = rota3.Trim();
        this.gameOver = gameOver.Trim();
        this.personagemDireita = personagemDireita.Trim();
        this.apareceDireita = apareceDireita.Trim();
        this.personagemEsquerda = personagemEsquerda.Trim();
        this.apareceEsquerda = apareceEsquerda.Trim();
        this.musicaASerDestruida = musicaASerDestruida.Trim();
        this.puloDeCena = puloDeCena.Trim();
    }
}