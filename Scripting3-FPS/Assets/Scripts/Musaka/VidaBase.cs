using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected int vidaMaxima = 100;
    protected int vidaActual;

    public int VidaMaxima => vidaMaxima;

    public int VidaActual
    {
        get { return vidaActual; }
    }



    protected Animator cmpAnimator;

    protected void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
        vidaActual = vidaMaxima;
    }

    public void QuitarVida(int daño)
    {
        vidaActual -= daño;
        if(vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        cmpAnimator.SetTrigger("die");
    }
}
