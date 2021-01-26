using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugadorAnimator : MonoBehaviour
{
    public float maxVelAndar = 2;
    public float maxVelCorrer = 5;
    public float maxVelAngular = 90;

    public bool usarRotacion = true;
    
    Animator cmpAnimator;

    private void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MovimientoYRotacion();
        Saltar();
    }

    // Para BlendTree de movimiento y rotación
    private void MovimientoYRotacion()
    {
        float xInput = Input.GetAxis("Horizontal");
        cmpAnimator.SetFloat("angularSpeed", xInput * maxVelAngular * Mathf.Deg2Rad);

        float zInput = Input.GetAxis("Vertical");
        float magnitudVelocidad = Input.GetKey(KeyCode.LeftShift) ? maxVelCorrer : maxVelAndar;
        cmpAnimator.SetFloat("speedZ", zInput * magnitudVelocidad);

    }

    // SIN USO: Para BlendTree de movimiento en XZ
    private void MovimientoXZ()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 inputNormalizado = new Vector3(xInput, 0, zInput);
        inputNormalizado.Normalize();

        float magnitudVelocidad = Input.GetKey(KeyCode.LeftShift) ? maxVelCorrer : maxVelAndar;
        Vector3 velXZLocal = inputNormalizado * magnitudVelocidad;
        cmpAnimator.SetFloat("speedX", velXZLocal.x);
        cmpAnimator.SetFloat("speedZ", velXZLocal.z);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cmpAnimator.SetTrigger("jump");
            cmpAnimator.SetTrigger("endJump");
        }
    }

}
