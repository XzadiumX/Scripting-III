using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grenade Info", menuName = "Grenade Info", order = 51)]
public class GrenadeInfo : ScriptableObject
{
    [SerializeField]
    private string g_name;

    public string name
    {
        get
        {
            return g_name;
        }
    }

    [SerializeField]
    private int g_damage;

    public int damage
    {
        get
        {
            return g_damage;
        }
    }

    [SerializeField]
    private float g_ForceThrow;

    public float impulse
    {
        get
        {
            return g_ForceThrow;
        }
    }

    [SerializeField]
    private float g_explosionForce;

    public float force
    {
        get
        {
            return g_explosionForce;
        }
    }

    [SerializeField]
    private int g_capacity;

    public int capacity
    {
        get
        {
            return g_capacity;
        }
    }

    [SerializeField]
    private float TimerBetweenGrenades;
    public float Timer
    {
        get
        {
            return TimerBetweenGrenades;
        }
    }

    [SerializeField]
    private float CDBetweenGrenades;
    public float CD
    {
        get
        {
            return CDBetweenGrenades;
        }
    }


}
