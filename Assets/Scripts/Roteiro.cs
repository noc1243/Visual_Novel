using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private int idAtual;

    private Button[] buttons3;
    private Button[] buttons2;

    private Script scriptASerExibido;

    private String imagemAtual;
    private String musicaAtual;

    private bool loadingGame;

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

            scripts.Add (new Script (colunas[0], colunas[1], colunas[2], colunas[3], colunas[4], colunas[5], colunas[6], colunas[7], colunas[8], colunas[9], colunas[10], colunas[11], colunas[12]));
        }
    }

    public void selecionaEscolha (int numeroEscolha) {
        idAtual = System.Convert.ToInt32 (scriptASerExibido.rota[numeroEscolha - 1]);

        carregaScript ();
    }

    private bool carregaImagem (Script script) {
        if (!String.IsNullOrEmpty (script.background)) {
            imagemAtual = script.background;
            modificadorDeBackground.carregaImagem (Resources.Load<Sprite> (this.backgroundFolderPath + script.background));
            return true;
        } else {
            return false;
        }
    }

    private bool carregaImagem (String imagem) {
        if (!String.IsNullOrEmpty (imagem)) {
            imagemAtual = imagem;
            modificadorDeBackground.carregaImagem (Resources.Load<Sprite> (this.backgroundFolderPath + imagem));
            return true;
        } else {
            return false;
        }
    }

    private void carregaMusica (Script script) {
        if (!String.IsNullOrEmpty (script.musica)) {
            musicaAtual = script.musica;
            modificadorDeMusica.carregaMusica (Resources.Load<GameObject> (this.musicaFolderPath + script.musica));
        }
    }

    private void carregaMusica (String musica) {
        if (!String.IsNullOrEmpty (musica)) {
            musicaAtual = musica;
            modificadorDeMusica.carregaMusica (Resources.Load<GameObject> (this.musicaFolderPath + musica));
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
        if (!loadingGame) {
            carregaMusica (scriptASerExibido);
        } else {
            carregaMusica (PlayerPrefs.GetString ("Musica", musicaAtual));
            loadingGame = false;
        }
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

    private void loadCarregaScript () {
        scriptASerExibido = scripts.Find (x => x.id == this.idAtual.ToString ());
        
        String imagem = PlayerPrefs.GetString ("Imagem");
        String musica = PlayerPrefs.GetString ("Musica");


        carregaImagem (imagem);
        if (verificaSeEstaMudandoDeBackground ()) {
            return;
        }

        carregaMusica (musica);
        verificaEscolhasECarregaOpcoes ();
        modificadorDeTexto.mudaTextoASerExibido (scriptASerExibido.texto);
    }

    private void carregaButoes () {
        buttons3 = seletorDeEscolhas3.GetComponentsInChildren<Button> ();
        buttons2 = seletorDeEscolhas2.GetComponentsInChildren<Button> ();
    }

    void loadGame () {
        idAtual = PlayerPrefs.GetInt ("LinhaAtual", 1);
        loadCarregaScript ();
        carregaButoes ();
    }

    // Start is called before the first frame update
    void Start () {
        parseiaScript ();

        if (PlayerPrefs.GetInt ("Load", 0) == 1) {
            PlayerPrefs.SetInt ("Load", 0);
            loadingGame = true;
            loadGame ();
        } 
        else {
            loadingGame = false;
            idAtual = 1;
            carregaScript ();
            carregaButoes ();
        }

    }

    private void gameOver () {
        SceneManager.LoadScene("GameOver");
    }

    private void verificaEPassaDeScript () {
        if (Input.GetButtonDown ("Enter") && String.IsNullOrEmpty (scriptASerExibido.escolha[0]) && !modificadorDeBackground.mudandoBackground) {
            if (!String.IsNullOrEmpty (scriptASerExibido.gameOver)) {
                gameOver ();
            }

            if (!modificadorDeTexto.mudandoTexto) {
                this.idAtual++;
                this.carregaScript ();
            } else {
                modificadorDeTexto.forcaTexto ();
            }
        }
    }

    public void saveGame () {
        PlayerPrefs.SetInt ("LinhaAtual", idAtual);
        PlayerPrefs.SetString ("Imagem", imagemAtual);
        PlayerPrefs.SetString ("Musica", musicaAtual);
    }

    // Update is called once per frame
    void Update () {
        this.verificaEPassaDeScript ();
    }
}