using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera maincamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
