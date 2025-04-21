using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    string mainMenu = "Menu";

    // load Menu scene when ESC is pressed
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    // load Menu scene
    public void Back()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
