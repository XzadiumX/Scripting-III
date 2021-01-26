using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentLanguage : PersistentSingleton<PersistentLanguage>
{
    public string LanguageToString;
    Interaction_UI player_UI;
    private void Start()
    {
        player_UI = FindObjectOfType<Interaction_UI>();
        if(player_UI != null)
        {
            player_UI.Language = LanguageToString;
        }
        else
        {
            Debug.Log("nOPE");
        }
    }
}
