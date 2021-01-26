using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interaction_UI : MonoBehaviour
{

    public string InteractionLanguage;
    public TextMeshProUGUI WeaponDescription;
    public TextMeshProUGUI InteractTextInfo;
    public Image WeaponImage;
    public bool IsActive;
    public string Language;
    public string ItemName;
    public GameObject CanvasUI;
    PersistentLanguage Language_reference;
    // Start is called before the first frame update
    void Start()
    {
        Language_reference = FindObjectOfType<PersistentLanguage>();
        Language = Language_reference.LanguageToString;
        IsActive = false;
        InteractionLanguage = "Spanish";
        ItemName = "Pistol";
    }
    void Update()
    {
        if(ItemName != null)
        {
            Debug.Log("ItemName");
            switch (Language)
            {
                case "Spanish":
                    switch (ItemName)
                    {
                        case "Pistol":
                            WeaponDescription.text = "Pistola, de calibre preciso";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;

                        case "Machinegun":
                            WeaponDescription.text = "Ametralladora, para varios objetivos";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";

                            return;

                        case "Ak47":
                            WeaponDescription.text = "Ak47, para eliminar enemigos rapidamente";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;

                        case "ShotGun":
                            WeaponDescription.text = "Escopeta, perfecta para grupos";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;

                        case "PistolAmmo":

                            WeaponDescription.text = "Municion Pistola, de calibre preciso¨Conseguiras 20 de municion¨";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;

                        case "MachinegunAmmo":
                            WeaponDescription.text = "Municion de Ametralladora, para varios objetivos ¨Conseguiras 20 de municion¨";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;

                        case "Ak47Ammo":
                            WeaponDescription.text = "Municion Ak47, para eliminar enemigos rapidamente ¨Conseguiras 16 de municion¨";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;
                        case "ShotGunAmmo":
                            WeaponDescription.text = "Municion Escopeta, perfecta para grupos ¨¨Conseguiras 5 de municion¨";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;
                        case "Health":
                            WeaponDescription.text = "Jeringuilla, elemento curativo que alivia el dolor, ¨Conseguiras 20 de vida¨";
                            InteractTextInfo.text = "Pulsa E para interactuar con el objeto";
                            return;
                    }

                    return;
                case "English":
                    switch (ItemName)
                    {
                        case "Pistol":
                            WeaponDescription.text = "Pistol, precise caliber";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;

                        case "Machinegun":
                            WeaponDescription.text = "Machine Gun, for various purposes";
                            InteractTextInfo.text = "Press E to interact with the object";

                            return;

                        case "Ak47":
                            WeaponDescription.text = "Ak47, to eliminate enemies quickly";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;

                        case "ShotGun":
                            WeaponDescription.text = "Shotgun, perfect for groups";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;

                        case "PistolAmmo":
                            WeaponDescription.text = "Pistol ammunition, of precise caliber ¨You will get 20 ammunition¨";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;

                        case "MachinegunAmmo":
                            WeaponDescription.text = "Machine Gun Ammunition, for various purposes ¨You will get 20 ammunition¨";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;

                        case "Ak47Ammo":
                            WeaponDescription.text = "Ak47 ammunition, to eliminate enemies quickly ¨You will get 16 ammunition¨";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;
                        case "ShotGunAmmo":
                            WeaponDescription.text = "Shotgun ammunition, perfect for groups ¨You will get 5 ammunition¨";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;
                        case "Health":
                            WeaponDescription.text = "Syringe, healing element that relieves pain, ¨You will get 20 life¨";
                            InteractTextInfo.text = "Press E to interact with the object";
                            return;
                    }
                    return;

                case "French":
                    switch (ItemName)
                    {
                        case "Pistol":
                            WeaponDescription.text = "Pistolet, calibre précis";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;

                        case "Machinegun":
                            WeaponDescription.text = "Mitrailleuse, à des fins diverses";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";

                            return;

                        case "Ak47":
                            WeaponDescription.text = "Ak47, pour éliminer rapidement les ennemis";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;

                        case "ShotGun":
                            WeaponDescription.text = "Shotgun, parfait pour les groupes";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;

                        case "PistolAmmo":
                            WeaponDescription.text = "Munitions de pistolet, de calibre précis ¨Vous obtiendrez 20 munitions¨";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;

                        case "MachinegunAmmo":
                            WeaponDescription.text = "Munitions de mitrailleuse, à des fins diverses ¨vous obtiendrez 20 munitions¨";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;

                        case "Ak47Ammo":
                            WeaponDescription.text = "Munitions Ak47, pour éliminer rapidement les ennemis ¨Vous obtiendrez 16 munitions¨";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;
                        case "ShotGunAmmo":
                            WeaponDescription.text = "Munitions de fusil de chasse, parfaites pour les groupes,¨ Vous recevrez 5 munitions¨";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;
                        case "Health":
                            WeaponDescription.text = "Seringue, élément de guérison qui soulage la douleur, ¨Vous obtiendrez 20 points de vie¨";
                            InteractTextInfo.text = "Appuyez sur E pour interagir avec l'objet";
                            return;
                    }
                    return;

                default:
                    switch (ItemName)
                    {
                        case "Pistol":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;

                        case "Machinegun":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";

                            return;

                        case "Ak47":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;

                        case "ShotGun":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;

                        case "PistolAmmo":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;

                        case "MachinegunAmmo":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;

                        case "Ak47Ammo":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;
                        case "ShotGunAmmo":
                            WeaponDescription.text = "Hola";
                            InteractTextInfo.text = "Hola";
                            return;
                        case "Health":
                            WeaponDescription.text = "Adios";
                            InteractTextInfo.text = "Hola";
                            return;
                    }
                    return;
            }
        }
    }
}
