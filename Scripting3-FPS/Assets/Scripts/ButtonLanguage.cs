﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLanguage : MonoBehaviour
{
    PersistentLanguage language;
    void Start()
    {
       language = FindObjectOfType<PersistentLanguage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Español()
    {
        language.LanguageToString = "Spanish";
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
    }

    public void Inglés()
    {
        language.LanguageToString = "English";
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
    }

    public void Frances()
    {
        language.LanguageToString = "French";
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
    }
}
