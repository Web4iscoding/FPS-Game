using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string selectMode = "SelectMode";
    string settings = "Settings";

    // load SelectMode scene
    public void StartGame()
    {
        SceneManager.LoadScene(selectMode);
    }

    // quit game
    public void CloseGame()
    {
        Application.Quit();
    }

    // open settings
    public void Settings()
    {
        SceneManager.LoadScene(settings);
    }
}
