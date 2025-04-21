using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    // Simple script for showing mouse when necessary
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
