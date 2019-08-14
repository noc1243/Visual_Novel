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

    // Update is called once per frame
    void Update()
    {
        
    }
}
