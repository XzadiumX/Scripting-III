using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaJugador : MonoBehaviour
{
    public int daño = 40;

    private void OnTriggerEnter(Collider other)
    {
        VidaEnemigo vidaEnemigo = other.GetComponent<VidaEnemigo>();
        if(vidaEnemigo != null)
        {
            vidaEnemigo.QuitarVida(daño);
        }
    }
}
