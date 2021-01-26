using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public float rangoAtaque = 5;
    public float tiempoEntreAtaques = 3;
    public float probabilidadAtaqueFuerte = 0.2f;
    
    VidaJugador vidaJugador;
    Animator cmpAnimator;
    

    bool atacando = false; 
        
    void Awake()
    {
        vidaJugador = FindObjectOfType<VidaJugador>();
        cmpAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distancia = Vector3.Distance(this.transform.position, vidaJugador.transform.position);
        if(distancia < rangoAtaque)
        {
            Vector3 posicionJugador = vidaJugador.transform.position;
            posicionJugador.y = this.transform.position.y;
            transform.LookAt(posicionJugador);
            
            if(!atacando)
            {
                atacando = true;
                InvokeRepeating("Atacar", tiempoEntreAtaques, tiempoEntreAtaques);
            }
        }
        else
        {
            if (atacando)
            {
                atacando = false;
                CancelInvoke("Atacar");
            }
        }
    }

    void Atacar()
    {
        bool ataqueFuerte = (Random.value < probabilidadAtaqueFuerte);
        if(ataqueFuerte)
        {
            cmpAnimator.SetTrigger("strongAttack");
        }
        else
        {
            cmpAnimator.SetTrigger("attack");
        }
    }

    void AnimEventDañarAlJugador(int daño)
    {
        vidaJugador.QuitarVida(daño);
        //vidaJugador.vidaActual -= daño;
    }
}
