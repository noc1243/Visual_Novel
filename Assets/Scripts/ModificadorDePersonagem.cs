using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificadorDePersonagem : MonoBehaviour
{
    [SerializeField] private Image personagemDireita;
    [SerializeField] private Image personagemEsquerda;

    [HideInInspector] public bool mudandoPersonagem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mudaPersonagemDireita (Sprite personagem) {
        personagemDireita.sprite = personagem;
        personagemDireita.gameObject.SetActive(true);
    }

    public void mudaPersonagemEsquerda (Sprite personagem) {
        personagemEsquerda.sprite = personagem;
        personagemEsquerda.gameObject.SetActive(true);
    }

    public void escondePersonagemDireita () {
        personagemDireita.gameObject.SetActive(false);
    }

    public void escondePersonagemEsquerda () {
        personagemEsquerda.gameObject.SetActive(false);
    }

}
