using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour
{
    // Start is called before the first frame update
    // Simple script for hiding mouse during gameplay
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
