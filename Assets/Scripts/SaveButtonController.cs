using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonController : MonoBehaviour
{
    [SerializeField] private GameObject saveButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desativaOuAtivaButao ();
    }

    public void desativaOuAtivaButao () {
        if (Input.GetButtonDown ("Esc")) {
            saveButton.SetActive (!saveButton.activeSelf);
        }
    }

    public void terminaSave () {
        saveButton.SetActive (false);
    }
}
