using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour {

    [SerializeField] Collider espada;
    Animator cmpAnimator;
    bool atacando = false;

    private void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
    }
        
    void Start () {
        espada.enabled = false;	
	}
		
	void Update () {
        Ataque();
        AtaqueFuerte();	
	}

    private void Ataque()
    {
        if (!atacando && Input.GetMouseButtonDown(0))
        {
            cmpAnimator.SetTrigger("attack");
        }
        else
        {
            cmpAnimator.ResetTrigger("attack");
        }
    }

    private void AtaqueFuerte()
    {
        if (!atacando && Input.GetMouseButtonDown(1))
        {
            cmpAnimator.SetTrigger("strongAttack");
        }
        else
        {
            cmpAnimator.ResetTrigger("strongAttack");
        }
    }

    
    void AnimEventComenzarAtaque()
    {
        print("Comenzar ataque");
        atacando = true;
    }

    
    void AnimEventFinalizarAtaque()
    {
        print("Finalizar ataque");
        atacando = false;
    }
    
    void AnimEventActivarTriggerEspada()
    {
        espada.enabled = true;
    }
    
    void AnimEventDesactivarTriggerEspada()
    {
        espada.enabled = false;
    }

}
