using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;
    public VidaBase vida;
    
    // Update is called once per frame
    void Update()
    {
        float vidaActual = vida.VidaActual;
        float vidaMaxima = vida.VidaMaxima;
        float porcentajeVida = vidaActual / vidaMaxima;
        barraVida.fillAmount = porcentajeVida;
    }
}
