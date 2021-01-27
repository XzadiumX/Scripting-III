using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBehaviour : MonoBehaviour
{
    public enum ShootStyle { MachineGun, Pistol, Ak47, ShotGun }
    public ShootStyle ShootRate;

    [Header("Weapon")]
    public int MaxMagazine;
    public int CurrentMagazine;
    public int MaxAmmo;
    public int CurrentAmmo;
    public int DamageBullet;
    public float TimerShootRate;
    public float CDShootRate;
    public float TimerReload;
    public float CDReload;
    public float MaxAmmountBurstBullets;
    public float CurrentAmmountBurstBullets;
    public float MaxAmountShotGunBullets;
    public float TimerBurst;
    public float CDBurst;
    public int BulletsGetItFromReload;
    public GameObject InstancePoint;
    string GunName;
    public bool HasTheGun;
    bool reloading;
    bool CanShoot;
    public bool CantReload;
    public float BulletForce;
    Vector3 DirectionForward;
    float accuracyModifier;
    float currentAccuracy;
    float accuracyDropPerShot;
    float accuracy;
    float accuracyPerSecond;

    public WeaponManager w_manager;
    public TextMeshProUGUI CurrentAmmo_text;
    public TextMeshProUGUI CurrentMagazine_text;
    public Sprite weapon_image;
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
        CurrentAmmo_text.text = CurrentAmmo.ToString();
        CurrentMagazine_text.text = CurrentMagazine.ToString();

        Debug.DrawLine(InstancePoint.transform.position, DirectionForward);
    }

    void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R) && !reloading && !CantReload)
        {
            w_manager.IsBusy = true;
            reloading = true;
            TimerReload = CDReload;
        }

        if(TimerReload <= 0 && reloading)
        {
            if(CurrentMagazine >= BulletsGetItFromReload)
            {
                CurrentAmmo += Mathf.Clamp(BulletsGetItFromReload, 0, MaxAmmo);
                CurrentMagazine -= Mathf.Clamp(BulletsGetItFromReload, 0, MaxAmmo);
                if(CurrentMagazine == 0)
                {
                    CantReload = true;
                }
            }
            else if(CurrentMagazine < BulletsGetItFromReload)
            {
                CurrentAmmo += CurrentMagazine;
                CurrentMagazine = 0;
                CantReload = true;
            }
            reloading = false;
            w_manager.IsBusy = false;
        }
    }

    void Timer()
    {
        TimerShootRate -= Time.deltaTime;
        TimerBurst -= Time.deltaTime;
        TimerReload -= Time.deltaTime;
    }
    void Shoot()
    {
        if(!reloading)
        {
            switch (GunName)
            {
                case "MachineGun":
                    if (Input.GetMouseButton(0) && TimerShootRate <= 0 && CurrentAmmo > 0)
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
                            }

                            else if (hit.collider.tag == "Enemy")
                            {
                                hit.collider.gameObject.GetComponent<VidaEnemigo>().QuitarVida(DamageBullet);
                            }
                            else
                            {
                                Debug.Log("No ha impactado");
                            }
                            CurrentAmmo--;
                        }




                    }
                    return;
                case "Pistol":
                    if (Input.GetMouseButtonDown(0) && !reloading && CurrentAmmo > 0)
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
                            }

                            else if (hit.collider.gameObject.tag == "Enemy")
                            {
                                Debug.Log("Hola");
                                hit.collider.gameObject.GetComponent<VidaEnemigo>().QuitarVida(DamageBullet);
                            }

                            else
                            {
                                Debug.Log("No ha impactado");
                            }
                            CurrentAmmo--;
                        }

                    }
                    return;
                case "Ak47":
                    if (Input.GetMouseButton(0) && TimerShootRate <= 0 && TimerBurst <= 0 && !reloading && CurrentAmmo > 0)
                    {
                        if (CurrentAmmountBurstBullets > 0)
                        {
                            TimerBurst = CDBurst;
                            CurrentAmmountBurstBullets--;
                        }
                        else if (CurrentAmmountBurstBullets <= 0)
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
                            }

                            else if (hit.collider.gameObject.tag == "Enemy")
                            {
                                Debug.Log("Hola");
                                hit.collider.gameObject.GetComponent<VidaEnemigo>().QuitarVida(DamageBullet);
                            }

                            else
                            {
                                Debug.Log("No ha impactado");
                            }
                            CurrentAmmo--;
                        }
                        //if (TimerReload <= 0 && TimerShootRate <= 0 && CurrentAmmo >= 0)
                        //{

                        //}

                        //else


                    }
                    return;
                case "ShotGun":
                    if (Input.GetMouseButtonDown(0) && !reloading && CurrentAmmo > 0)
                    {
                        //if (TimerReload <= 0 && CurrentAmmo >= 0)
                        //{

                        //}
                        Debug.Log("PAM");
                        for (int i = 0; i < MaxAmountShotGunBullets; i++)
                        {
                            Debug.Log("PUM");
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
                                }

                                else if (hit.collider.gameObject.tag == "Enemy")
                                {
                                    Debug.Log("Hola");
                                    hit.collider.gameObject.GetComponent<VidaEnemigo>().QuitarVida(DamageBullet);
                                }

                                else
                                {
                                    Debug.Log("No ha impactado");
                                }
                                CurrentAmmo--;
                            }
                        }
                    }
                    return;

            }
        }
    }
}
