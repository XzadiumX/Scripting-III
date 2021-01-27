using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{

    public GameObject m_mainMenu;
    public GameObject m_options;
    public GameObject m_languages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnOnePlayer()
    {
        Blackboard.m_gameType = GameType.PLAYER_VS_AI;

        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
    }
    public void OnOptions(bool isOptions)
    {
        m_mainMenu.SetActive(!isOptions);
        m_options.SetActive(isOptions);
    }
    public void Language(bool islanguages)
    {
        m_options.SetActive(!islanguages);
        m_languages.SetActive(islanguages);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void SetFullScreen(bool isFullcreen)
    {
        Screen.fullScreen = isFullcreen;
    }


}

