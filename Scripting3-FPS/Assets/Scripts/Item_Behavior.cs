using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Behavior : MonoBehaviour
{

    public enum Item { MachinegunAmmo, PistolAmmo, Ak47Ammo, ShotGunAmmo, Health, Machinegun, Pistol, Ak47, ShotGun}
    public Item Item_Behave;
    public Sprite Item_Image;
    public string Item_name;
    public bool CanTakeIt;
    public int Value;
    public Interaction_UI player_UI;
    public WeaponBehaviour weapon_behave;
    // Start is called before the first frame update
    void Start()
    {
        //player_UI = FindObjectOfType<Interaction_UI>();
        Item_name = Item_Behave.ToString();
        Debug.Log(Item_name);
    }

    // Update is called once per frame

    public void Observe()
    {

        switch (Item_name)
        {
            case "MachinegunAmmo":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;

            case "PistolAmmo":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;

            case "Ak47Ammo":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;

            case "ShotGunAmmo":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;

            case "Health":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;
            case "Machinegun":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;
            case "Pistol":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;
            case "Ak47":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;
            case "ShotGun":
                player_UI.ItemName = Item_name;
                player_UI.WeaponImage.sprite = Item_Image;
                return;
        }
    }

    public void Take()
    {
        switch (Item_name)
        {
            case "MachinegunAmmo":
                weapon_behave.CurrentMagazine += Value;
                weapon_behave.CurrentMagazine = Mathf.Clamp(weapon_behave.CurrentMagazine, 0, weapon_behave.MaxMagazine);
                Destroy(this.gameObject);
                return;

            case "PistolAmmo":
                weapon_behave.CurrentMagazine += Value;
                weapon_behave.CurrentMagazine = Mathf.Clamp(weapon_behave.CurrentMagazine, 0, weapon_behave.MaxMagazine);
                Destroy(this.gameObject);
                return;

            case "Ak47Ammo":
                weapon_behave.CurrentMagazine += Value;
                weapon_behave.CurrentMagazine = Mathf.Clamp(weapon_behave.CurrentMagazine, 0, weapon_behave.MaxMagazine);
                Destroy(this.gameObject);
                return;

            case "ShotGunAmmo":
                weapon_behave.CurrentMagazine += Value;
                weapon_behave.CurrentMagazine = Mathf.Clamp(weapon_behave.CurrentMagazine, 0, weapon_behave.MaxMagazine);
                Destroy(this.gameObject);
                return;

            case "Health":

                return;

        }
    }
}
