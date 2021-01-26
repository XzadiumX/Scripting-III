using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : VidaBase
{

    protected override void Morir()
    {
        base.Morir();
        
        print("Enemigo muere");
        Destroy(this.gameObject, 5);
    }
}
