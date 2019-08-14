using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificadorDeMusica : MonoBehaviour {
    private AudioSource musica;

    // Start is called before the first frame update
    void Start () {
        musica = gameObject.GetComponent<AudioSource> ();
    }

    public void carregaMusica (AudioClip musica) {
        this.musica.clip = musica;
        this.musica.loop = true;
        this.musica.Play (0);
    }

    // Update is called once per frame
    void Update () {

    }
}