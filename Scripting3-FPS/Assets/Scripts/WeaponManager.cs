using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject[] weapons;
    WeaponBehaviour[] w_behave;
    int WeaponByNumber;
    public bool IsBusy;
    void Start()
    {
        foreach (var a in weapons)
        {
            a.SetActive(false);
        }
        weapons[WeaponByNumber].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsBusy)
        {
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (WeaponByNumber < weapons.Length -1)
            {
                WeaponByNumber++;
            }
            foreach (var a in weapons)
            {
                a.SetActive(false);
            }
            Debug.Log(WeaponByNumber);
            
            weapons[WeaponByNumber].SetActive(true);
        }

        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (WeaponByNumber > 0)
            {
                WeaponByNumber--;
            }
            Debug.Log(WeaponByNumber);
            foreach (var a in weapons)
            {
                a.SetActive(false);
            }
            weapons[WeaponByNumber].SetActive(true);
        }
    }
}
