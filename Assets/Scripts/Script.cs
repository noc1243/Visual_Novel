using System.Collections;
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


    public Script (string id, string texto, string background, string musica, string efeito, string personagens, string escolha1, string escolha2, string escolha3, string rota1, string rota2, string rota3) {
        escolha = new string [3];
        rota = new string [3];


        this.id = id;
        this.texto = texto;
        this.background = background;
        this.musica = musica;
        this.efeito = efeito;
        this.personagens = personagens;
        this.escolha [0] = escolha1;
        this.escolha [1] = escolha2;
        this.escolha [2] = escolha3;
        this.rota [0] = rota1;
        this.rota [1] = rota2;
        this.rota [2] = rota3;
    }
}