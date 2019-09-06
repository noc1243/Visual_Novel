using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonController : MonoBehaviour {
    [SerializeField] private GameObject saveButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject titleScreenButton;
    [SerializeField] private GameObject menuBackground;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        desativaOuAtivaButao ();
    }

    public void desativaOuAtivaButao () {
        if (Input.GetButtonDown ("Esc")) {
            saveButton.SetActive (!saveButton.activeSelf);
            exitButton.SetActive (!exitButton.activeSelf);
            titleScreenButton.SetActive (!titleScreenButton.activeSelf);
            menuBackground.SetActive (!menuBackground.activeSelf);
        }

        if (Input.GetButtonDown ("Enter")) {
            saveButton.SetActive (false);
            exitButton.SetActive (false);
            titleScreenButton.SetActive (false);
            menuBackground.SetActive (false);
        }
    }

    public void terminaSave () {
        saveButton.SetActive (false);
        exitButton.SetActive (false);
        titleScreenButton.SetActive (false);
        menuBackground.SetActive (false);
    }
}