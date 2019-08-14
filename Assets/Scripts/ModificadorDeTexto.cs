using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ModificadorDeTexto : MonoBehaviour
{
    [SerializeField] private int speedOfChangingText = 1;
    [SerializeField] private float tempoEntreAtualizacoesDeTexto = 1.0f;
    [SerializeField] private GameObject downArrow;


    [HideInInspector] public bool mudandoTexto;
    private Text textoNaTela;
    private string textoASerExibido;
    private float tempoDaUltimaAtualizacaoDeTexto;

    // Start is called before the first frame update
    void Start()
    {
        textoNaTela = gameObject.GetComponent<Text> ();
        textoASerExibido = textoNaTela.text;
        mudandoTexto = false;
        tempoDaUltimaAtualizacaoDeTexto = 0.0f;
    }

    public void mudaTextoASerExibido (string textoASerExibido) {
        this.textoASerExibido = textoASerExibido;
        textoNaTela.text = "";
        mudandoTexto = true;
        downArrow.SetActive (false);
    }

    private bool verificaSeTerminouDeMudarTexto () {
        return string.Equals (textoNaTela.text, this.textoASerExibido);
    }

    private void atualizaTextoNaTela () {
        int finalLenghtSubString = Math.Min(this.textoASerExibido.Length, textoNaTela.text.Length + speedOfChangingText);
        textoNaTela.text = this.textoASerExibido.Substring (0, finalLenghtSubString);
    }

    private void verificaEAtualizaTextoNaTela () {
        if (tempoDaUltimaAtualizacaoDeTexto > tempoEntreAtualizacoesDeTexto) {
            tempoDaUltimaAtualizacaoDeTexto = 0.0f;
            atualizaTextoNaTela ();

            if (verificaSeTerminouDeMudarTexto ()) {
                mudandoTexto = false;
                downArrow.SetActive (true);
            }
        } else
        {
            tempoDaUltimaAtualizacaoDeTexto += Time.deltaTime;
        }
    }

    public void forcaTexto () {
        tempoDaUltimaAtualizacaoDeTexto = 0.0f;
        textoNaTela.text = this.textoASerExibido;
        mudandoTexto = false;
        downArrow.SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
        if (mudandoTexto) {
            verificaEAtualizaTextoNaTela ();
        }
    }
}