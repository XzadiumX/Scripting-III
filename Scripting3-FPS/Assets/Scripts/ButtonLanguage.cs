using System.Collections;
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
    public void Español()
    {
        language.LanguageToString = "Spanish";
    }

    public void Inglés()
    {
        language.LanguageToString = "English";
    }

    public void Frances()
    {
        language.LanguageToString = "French";
    }
}
