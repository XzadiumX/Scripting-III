using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlEnemigo : MonoBehaviour {

    enum EstadoEnemigo
    {
        VolviendoAlOrigen,
        PersiguiendoAlJugador,
        Patrullando
    }

    public float radioAlerta = 5;
    public float radioMovAleatorio = 5;      
    public float distanciaVueltaAlSpawn = 15;
    public float distanciaParada = 2;

    Vector3 puntoSpawn;
    Vector3 puntoDestino;

    EstadoEnemigo estado;

    NavMeshAgent cmpAgent;
    Transform jugador;
    
    
    private void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
        jugador = GameObject.FindWithTag("Player").transform;
        puntoSpawn = this.transform.position;

        estado = EstadoEnemigo.Patrullando;
        IrAPosicionAleatoria();
    }
	
	// Update is called once per frame
	void Update () {
        if(estado == EstadoEnemigo.Patrullando)
        {
            ComprobarDistanciaAJugador();
            ComprobarDestinoAlcanzado();
        }
        else if(estado == EstadoEnemigo.PersiguiendoAlJugador)
        {
            PerseguirAlJugador();
            ComprobarDistanciaAPuntoSpawn();
        }
        else if(estado == EstadoEnemigo.VolviendoAlOrigen)
        {
            ComprobarDestinoAlcanzado();
        }
	}

    void IrAPosicionAleatoria()
    {
        Vector3 puntoEnCirculo = Random.insideUnitSphere;
        puntoEnCirculo.y = 0;

        puntoDestino = puntoSpawn + puntoEnCirculo * radioMovAleatorio;

        cmpAgent.stoppingDistance = 0;
        cmpAgent.SetDestination(puntoDestino);
    }

    void VolverAlOrigen()
    {
        estado = EstadoEnemigo.VolviendoAlOrigen;
        IrAPosicionAleatoria();
    }

    void PerseguirAlJugador()
    {        
        estado = EstadoEnemigo.PersiguiendoAlJugador;

        cmpAgent.stoppingDistance = distanciaParada;
        cmpAgent.SetDestination(jugador.position);
    }

    void ComprobarDestinoAlcanzado()
    {
        if(cmpAgent.remainingDistance < 1)
        {
            estado = EstadoEnemigo.Patrullando;
            IrAPosicionAleatoria();
        }
    }

    void ComprobarDistanciaAJugador()
    {
        float distanciaAlJugador = Vector3.Distance(this.transform.position, jugador.transform.position);
        if(distanciaAlJugador < radioAlerta)
        {
            PerseguirAlJugador();
        }
    }

    void ComprobarDistanciaAPuntoSpawn()
    {
        float distanciaAlSpawn = Vector3.Distance(transform.position, puntoSpawn);
        if(distanciaAlSpawn > distanciaVueltaAlSpawn)
        {
            VolverAlOrigen();
        }
    }

}
