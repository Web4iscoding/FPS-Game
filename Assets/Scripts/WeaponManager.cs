using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // WeaponManager Singleton

    public static WeaponManager Instance { get; set; }

    // slot 0 = pistol
    // slot 1 = ak47
    // slot 2 = bat
    public List<GameObject> weaponSlots;

    public GameObject activeSlot;

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

    private void Start()
    {
        // set pistol as default active slot
        activeSlot = weaponSlots[0];
    }

    // managing and upating active weapon slot
    private void Update()
    {
       foreach (GameObject weaponSlot in weaponSlots)
       {
            if (weaponSlot == activeSlot)
            {
                weaponSlot.SetActive(true);
            }
            else
            {
                weaponSlot.SetActive(false);
            }
       }

       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
            SwitchActiveSlot(0);
       }
       if (Input.GetKeyDown(KeyCode.Alpha2))
       {
            SwitchActiveSlot(1);
       }

       if (Input.GetKeyDown(KeyCode.Q))
       {
            SwitchActiveSlot(2);
       }
    }

    // switch active slot (current weapon)
    private void SwitchActiveSlot(int slotNumber)
    {
        activeSlot = weaponSlots[slotNumber];
    }
}
