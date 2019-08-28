using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificadorDeBackground : MonoBehaviour
{
    public GameObject fadeInFadeout;

    private Image background;
    private Sprite spriteAtual;

    public bool mudandoBackground;

    // Start is called before the first frame update
    void Start()
    {
        background = gameObject.GetComponent<Image> ();
    }

    void Awake () {
        mudandoBackground = false;
    }

    public void atualizaBackground () {
        this.background.sprite = spriteAtual;
    }

    public void carregaImagem (Sprite sprite) {
        fadeInFadeout.SetActive (true);
        spriteAtual = sprite;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
