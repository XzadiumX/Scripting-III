using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GrenadeInfo g_data;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(g_data.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
