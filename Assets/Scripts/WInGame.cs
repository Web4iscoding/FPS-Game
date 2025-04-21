using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WInGame : MonoBehaviour
{
    // return to Menu scene when battle mode is over
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            SceneManager.LoadScene("Menu");

    }
}
