using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingSlideBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider LoadingBar;
    public TextMeshProUGUI LoadingText;
    int Counter;
    bool CountUp;
    bool Ended;
    void Start()
    {
        LoadingBar.value = 0;
        CountUp = true;
    }
    void Update()
    {
        if(CountUp)
        {
            LoadingBar.value += Time.deltaTime;
            Counter = (int)LoadingBar.value * 20;
            LoadingText.text = Counter.ToString() + " %";
        }
        if(Counter == (int)100 && !Ended)
        {
            SceneManager.LoadSceneAsync("Yago");
            Ended = true;
        }
    }
}
