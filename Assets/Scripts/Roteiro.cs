using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roteiro : MonoBehaviour {
    [SerializeField] private string roteiro = "roteiro";
    [SerializeField] private string CSV_SEPARATOR = ";_;";
    [SerializeField] private ModificadorDeBackground modificadorDeBackground;
    [SerializeField] private ModificadorDeMusica modificadorDeMusica;
    [SerializeField] private GameObject seletorDeEscolhas3;
    [SerializeField] private GameObject seletorDeEscolhas2;
    [SerializeField] private ModificadorDeTexto modificadorDeTexto;

    private string roteiroFolderPath = "Roteiro/";
    private string backgroundFolderPath = "Backgrounds/";
    private string musicaFolderPath = "Musicas/";
    private List<Script> scripts;
    private int idAtual = 1;

    private Button[] buttons3;
    private Button[] buttons2;

    private Script scriptASerExibido;

    private void parseiaScript () {
        this.scripts = new List<Script> ();

        string path = roteiroFolderPath + roteiro;

        TextAsset asset = Resources.Load<TextAsset> (path);

        string[] linhas = asset.text.Split ('\n');

        bool cabecalho = true;
        foreach (string linha in linhas) {
            if (cabecalho) {
                cabecalho = false;
                continue;
            }

            string[] colunas = linha.Split (new string[] { this.CSV_SEPARATOR }, StringSplitOptions.None);

            scripts.Add (new Script (colunas[0], colunas[1], colunas[2], colunas[3], colunas[4], colunas[5], colunas[6], colunas[7], colunas[8], colunas[9], colunas[10], colunas[11]));
        }
    }

    public void selecionaEscolha (int numeroEscolha) {
        idAtual = System.Convert.ToInt32 (scriptASerExibido.rota[numeroEscolha - 1]);

        carregaScript ();
    }

    private bool carregaImagem (Script script) {
        if (!String.IsNullOrEmpty (script.background)) {
            modificadorDeBackground.carregaImagem (Resources.Load<Sprite> (this.backgroundFolderPath + script.background));
            return true;
        }
        else {
            return false;
        }
    }

    private void carregaMusica (Script script) {
        if (!String.IsNullOrEmpty (script.musica)) {
            modificadorDeMusica.carregaMusica (Resources.Load<AudioClip> (this.musicaFolderPath + script.musica));
        }
    }

    private void verificaEscolhasECarregaOpcoes () {

        if (!String.IsNullOrEmpty (scriptASerExibido.escolha[0])) {
            if (!String.IsNullOrEmpty (scriptASerExibido.escolha[2])) {
                seletorDeEscolhas3.SetActive (true);

                buttons3[0].GetComponentInChildren<Text> ().text = scriptASerExibido.escolha[0];
                buttons3[1].GetComponentInChildren<Text> ().text = scriptASerExibido.escolha[1];
                buttons3[2].GetComponentInChildren<Text> ().text = scriptASerExibido.escolha[2];

            } else {
                seletorDeEscolhas2.SetActive (true);

                buttons2[0].GetComponentInChildren<Text> ().text = scriptASerExibido.escolha[0];
                buttons2[1].GetComponentInChildren<Text> ().text = scriptASerExibido.escolha[1];
            }
        }
    }

    public void carregaScriptPosMudancaDeBackground () {
        carregaMusica (scriptASerExibido);
        verificaEscolhasECarregaOpcoes ();
        modificadorDeTexto.mudaTextoASerExibido (scriptASerExibido.texto);
    }

    private bool verificaSeEstaMudandoDeBackground () {
        return modificadorDeBackground.fadeInFadeout.active;
    }

    private void carregaScript () {
        scriptASerExibido = scripts.Find (x => x.id == this.idAtual.ToString ());

        carregaImagem (scriptASerExibido);
        if (verificaSeEstaMudandoDeBackground ()) {
            return;
        }

        carregaMusica (scriptASerExibido);
        verificaEscolhasECarregaOpcoes ();
        modificadorDeTexto.mudaTextoASerExibido (scriptASerExibido.texto);
    }

    private void carregaButoes () {
        buttons3 = seletorDeEscolhas3.GetComponentsInChildren<Button> ();
        buttons2 = seletorDeEscolhas2.GetComponentsInChildren<Button> ();
    }

    // Start is called before the first frame update
    void Start () {
        parseiaScript ();
        carregaScript ();
        carregaButoes ();
    }

    private void verificaEPassaDeScript () {
        if (Input.GetButtonDown ("Enter") && String.IsNullOrEmpty (scriptASerExibido.escolha[0])) {
            if (!modificadorDeTexto.mudandoTexto) {
                this.idAtual++;
                this.carregaScript ();
            } else {
                modificadorDeTexto.forcaTexto ();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        this.verificaEPassaDeScript ();
    }
}