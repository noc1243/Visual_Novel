using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private ModificadorDeBackground modificadorDeBackground;
    [SerializeField] private Roteiro roteiro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void atualizaBackgroundEVoltaACarregarScript () {
        modificadorDeBackground.atualizaBackground ();
        roteiro.carregaScriptPosMudancaDeBackground ();
    }

    void OnDisable () {
        modificadorDeBackground.mudandoBackground = false;
    }

    void OnEnable () {
        modificadorDeBackground.mudandoBackground = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
