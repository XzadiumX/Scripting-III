using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject[] weapons;
    int WeaponByNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (WeaponByNumber <= weapons.Length - 1)
            {
                WeaponByNumber++;
            }
            foreach (var a in weapons)
            {
                a.SetActive(false);
            }
            Debug.Log(WeaponByNumber);
            weapons[WeaponByNumber -1].SetActive(true);
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
            weapons[WeaponByNumber -1].SetActive(true);
        }
    }
}
