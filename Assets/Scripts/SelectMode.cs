using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    // SelectMode Singleton

    string normalMode = "SelectScenes";
    string battleMode = "Scene1";
    string mainMenu = "Menu";
    string tutorial = "Tutorial";

    public Mode mode;

    public static SelectMode Instance { get; set; }

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

    // load Menu scene when ESC is pressed
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    // Mode enum
    public enum Mode
    {
        Normal, Battle, Tutorial
    }

    // load SelectScenes scene
    public void NormalMode()
    {
        SceneManager.LoadScene(normalMode);
    }

    // load Scene1 scene of battle mode
    public void BattleMode()
    {
        mode = Mode.Battle;
        SceneManager.LoadScene(battleMode);
    }

    // load Tutorial scene
    public void TutorialMode()
    {
        mode = Mode.Tutorial;
        SceneManager.LoadScene(tutorial);
    }

    // load Menu scene
    public void Back()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
