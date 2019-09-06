﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame () {
        Application.Quit();
    }

    public void startGame (int loadOrStart) {
        PlayerPrefs.SetInt ("Load", loadOrStart);
        SceneManager.LoadScene("SampleScene");

    }

    public void goToTitleScreen (int loadOrStart) {
        SceneManager.LoadScene("TitleScreen");

    }
}
