using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : VidaBase
{
    protected override void Morir()
    {
        base.Morir();
        print("Jugador muere");        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
