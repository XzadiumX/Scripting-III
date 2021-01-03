using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public enum ShootStyle { MachineGun, Pistol, Ak47, ShotGun }
    public ShootStyle ShootRate;

    [Header("Weapon")]
    public int MaxMagazine;
    public int CurrentMagazine;
    public int MaxAmmo;
    public int CurrentAmmo;
    public float TimerShootRate;
    public float CDShootRate;
    public float TimerReload;
    public float CDReload;
    public float MaxAmmountBurstBullets;
    public float CurrentAmmountBurstBullets;
    public float MaxAmountShotGunBullets;
    public float TimerBurst;
    public float CDBurst;
    public GameObject InstancePoint;
    string GunName;

    bool reloading;
    bool CanShoot;
    public float BulletForce;
    Vector3 DirectionForward;
    float accuracyModifier;
    float currentAccuracy;
    float accuracyDropPerShot;
    float accuracy;
    float accuracyPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        GunName = ShootRate.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(InstancePoint.transform.position, InstancePoint.transform.forward * 10);
        Shoot();
        Reload();
        Timer();

        Debug.DrawLine(InstancePoint.transform.position, DirectionForward);
    }

    void Reload()
    {

    }

    void Timer()
    {
        TimerShootRate -= Time.deltaTime;
        TimerBurst -= Time.deltaTime;
        TimerReload -= Time.deltaTime;
    }
    void Shoot()
    {
        switch(GunName)
        {
            case "MachineGun":
                if(Input.GetMouseButton(0) && TimerShootRate<=0)
                {
                    TimerShootRate = CDShootRate;

                    //if(CurrentAmmo > 0 && TimerReload <= 0)
                    //{

                    //}

                    accuracyModifier = (100 - currentAccuracy) / 1000;
                    DirectionForward = InstancePoint.transform.forward;
                    DirectionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    currentAccuracy -= accuracyDropPerShot;
                    currentAccuracy = Mathf.Clamp(currentAccuracy, 0, 100);
                    currentAccuracy = Mathf.Lerp(currentAccuracy, accuracy, accuracyPerSecond * Time.deltaTime);
                    Ray Projectileray = new Ray(InstancePoint.transform.position, DirectionForward);
                    if (Physics.Raycast(Projectileray, out RaycastHit hit, 10))
                    {
                        if (hit.rigidbody)
                        {
                            hit.rigidbody.AddForce(Projectileray.direction * BulletForce);
                            Debug.Log(hit.rigidbody.gameObject.name);
                            CurrentAmmo--;
                        }

                        else
                        {
                            Debug.Log("No ha impactado");
                        }

                    }




                }
                return;
            case "Pistol":
                if (Input.GetMouseButtonDown(0) )
                {
                    //    //if(TimerReload <= 0 && CurrentAmmo >= 0)
                    //    //{

                    //    //}
                    accuracyModifier = (100 - currentAccuracy) / 1000;
                    DirectionForward = InstancePoint.transform.forward;
                    DirectionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    currentAccuracy -= accuracyDropPerShot;
                    currentAccuracy = Mathf.Clamp(currentAccuracy, 0, 100);
                    currentAccuracy = Mathf.Lerp(currentAccuracy, accuracy, accuracyPerSecond * Time.deltaTime);
                    Ray Projectileray = new Ray(InstancePoint.transform.position, DirectionForward);
                    if (Physics.Raycast(Projectileray, out RaycastHit hit, 10))
                    {
                        if (hit.rigidbody)
                        {
                            hit.rigidbody.AddForce(Projectileray.direction * BulletForce);
                            Debug.Log(hit.rigidbody.gameObject.name);
                            CurrentAmmo--;
                        }

                        else
                        {
                            Debug.Log("No ha impactado");
                        }
    
                    }
                   
                }
                return;
            case "Ak47":
                if (Input.GetMouseButton(0) && TimerShootRate<=0 && TimerBurst<=0)
                {
                    if(CurrentAmmountBurstBullets > 0)
                    {
                        TimerBurst = CDBurst;
                        CurrentAmmountBurstBullets--;
                    }
                    else if(CurrentAmmountBurstBullets <= 0)
                    {
                        TimerShootRate = CDShootRate;
                        CurrentAmmountBurstBullets = MaxAmmountBurstBullets;
                    }
                    accuracyModifier = (100 - currentAccuracy) / 1000;
                    DirectionForward = InstancePoint.transform.forward;
                    DirectionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    DirectionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                    currentAccuracy -= accuracyDropPerShot;
                    currentAccuracy = Mathf.Clamp(currentAccuracy, 0, 100);
                    currentAccuracy = Mathf.Lerp(currentAccuracy, accuracy, accuracyPerSecond * Time.deltaTime);
                    Ray Projectileray = new Ray(InstancePoint.transform.position, DirectionForward);
                    if (Physics.Raycast(Projectileray, out RaycastHit hit, 10))
                    {
                        if (hit.rigidbody)
                        {
                            hit.rigidbody.AddForce(Projectileray.direction * BulletForce);
                            Debug.Log(hit.rigidbody.gameObject.name);
                            CurrentAmmo--;
                        }

                        else
                        {
                            Debug.Log("No ha impactado");
                        }

                    }
                    //if (TimerReload <= 0 && TimerShootRate <= 0 && CurrentAmmo >= 0)
                    //{

                    //}

                    //else


                }
                return;
            case "ShotGun":
                if (Input.GetKeyDown(0))
                {
                    //if (TimerReload <= 0 && CurrentAmmo >= 0)
                    //{

                    //}
                    for (int i = 0; i < MaxAmountShotGunBullets; i++)
                    {
                        accuracyModifier = (100 - currentAccuracy) / 1000;
                        DirectionForward = InstancePoint.transform.forward;
                        DirectionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                        DirectionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                        DirectionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
                        currentAccuracy -= accuracyDropPerShot;
                        currentAccuracy = Mathf.Clamp(currentAccuracy, 0, 100);
                        currentAccuracy = Mathf.Lerp(currentAccuracy, accuracy, accuracyPerSecond * Time.deltaTime);
                        Ray Projectileray = new Ray(InstancePoint.transform.position, DirectionForward);
                        if (Physics.Raycast(Projectileray, out RaycastHit hit, 10))
                        {
                            if (hit.rigidbody)
                            {
                                hit.rigidbody.AddForce(Projectileray.direction * BulletForce);
                                Debug.Log(hit.rigidbody.gameObject.name);
                                CurrentAmmo--;
                            }

                            else
                            {
                                Debug.Log("No ha impactado");
                            }

                        }
                    }
                }
                return;

        }
    }
}
