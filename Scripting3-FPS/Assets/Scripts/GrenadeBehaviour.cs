using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    [SerializeField]
    private GrenadeInfo g_data;
    float countdown;
    float radius = 3;
    bool hasExploded;
    public ParticleSystem Particulas;
    float fExplosion;
    float arrojar;
    Rigidbody rb;
    int damageG;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(g_data.force);
        Debug.Log(g_data.name);
        float timer = g_data.Timer;
        fExplosion = g_data.force;
        arrojar = g_data.impulse;
        countdown = timer;
        damageG = g_data.damage;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*arrojar,ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        ParticleSystem efectoGranada = Instantiate(Particulas, this.transform.position, this.transform.rotation);
        Destroy(efectoGranada, 1);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position,radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fExplosion,transform.position,radius);
                
            }
            else if (nearbyObject.tag == "Enemy")
            {
                nearbyObject.gameObject.GetComponent<VidaEnemigo>().QuitarVida(damageG);
            }
        }
        
        hasExploded = true;
        Destroy(gameObject);
    }


}
