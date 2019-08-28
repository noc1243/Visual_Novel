using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificadorDeMusica : MonoBehaviour {

    private GameObject musicaObject;

    // Start is called before the first frame update
    void Start () {
        
    }

    public void carregaMusica (GameObject musica) {
        Destroy (musicaObject);
        musicaObject = (GameObject) Instantiate (musica);
        musicaObject.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {

    }
}