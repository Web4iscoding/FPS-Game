using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AmmoManager : MonoBehaviour
{
    // AmmoManager Singleton

    public static AmmoManager Instance { get; set; }

    public GameObject crosshair;
    
    [Header("Ammo")]
    public TextMeshProUGUI magazineAmmoUI;
    public TextMeshProUGUI totalAmmoUI;
    public Image ammoTypeUI;

    [Header("Gun")]
    public Image activeWeaponUI;
    public Image unactiveWeaponUI;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Gun activeWeapon = WeaponManager.Instance.activeSlot.GetComponentInChildren<Gun>();
        Gun unactiveWeapon = GetUnactiveSlot().GetComponentInChildren<Gun>();

        // Switch to meless weapon UI change
        if (activeWeapon.gunModel == Gun.Model.Bat){
            magazineAmmoUI.text = "";
            totalAmmoUI.text = "Melee";
            ammoTypeUI.color= new Color(255, 255, 255, 0);
            activeWeaponUI.color = new Color(255, 255, 255, 0);
            unactiveWeaponUI.color = new Color(255, 255, 255, 0);
        }

        // Switch to guns UI change
        else if (activeWeapon && activeWeapon.gunModel != Gun.Model.Bat)
        {
            magazineAmmoUI.text = $"{activeWeapon.bulletsLeft}";
            totalAmmoUI.text = $"{activeWeapon.size}";

            Gun.Model model = activeWeapon.gunModel;
            ammoTypeUI.sprite = GetAmmoSprite(model);

            activeWeaponUI.sprite = GetWeaponSprite(model);

            if (unactiveWeapon)
            {
                unactiveWeaponUI.sprite = GetWeaponSprite(unactiveWeapon.gunModel);
                unactiveWeaponUI.color = new Color(0, 0, 0);
            }
            ammoTypeUI.color= new Color(255, 255, 255);
            activeWeaponUI.color = new Color(255, 255, 255);
        }
    }

    // return Sprite object of ammo sprites
    private Sprite GetAmmoSprite(Gun.Model model)
    {
        switch (model)
        {    
            case Gun.Model.Pistol:
                return Resources.Load<GameObject>("Pistol_Ammo").GetComponent<SpriteRenderer>().sprite;
            case Gun.Model.AK47:
                return Resources.Load<GameObject>("AK47_Ammo").GetComponent<SpriteRenderer>().sprite;
            default:
                return null;
        }
    }

    // return Sprite object of weapon sprites
    private Sprite GetWeaponSprite(Gun.Model model)
    {
        switch (model)
        {    
            case Gun.Model.Pistol:
                return Resources.Load<GameObject>("Pistol_Gun").GetComponent<SpriteRenderer>().sprite;
            case Gun.Model.AK47:
                return Resources.Load<GameObject>("AK47_Gun").GetComponent<SpriteRenderer>().sprite;
            default:
                return null;
        }
    }

    // return GameObject of unactive weapon
    private GameObject GetUnactiveSlot()
    {
        foreach (GameObject weaponslot in WeaponManager.Instance.weaponSlots)
        {
            if (weaponslot != WeaponManager.Instance.activeSlot)
            {
                return weaponslot;
            }
        }
        return null;
    }
}
