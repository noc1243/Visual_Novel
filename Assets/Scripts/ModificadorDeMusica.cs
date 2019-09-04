using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificadorDeMusica : MonoBehaviour {

    Dictionary<string, GameObject> musicas;

    // Start is called before the first frame update
    void Start () {
        musicas = new Dictionary <string, GameObject>();
    }

    public void carregaMusica (GameObject musica, string nomeMusica) {
        if (musicas.ContainsKey (nomeMusica)) {
            Destroy (musicas[nomeMusica]);
        }

        GameObject musicaObject = (GameObject) Instantiate (musica);
        musicaObject.transform.position = gameObject.transform.position;
        musicas[nomeMusica] = musicaObject;
    }

    public void destroiMusica (string nomeMusica) {
        if (musicas.ContainsKey (nomeMusica)) {
            Destroy (musicas[nomeMusica]);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}