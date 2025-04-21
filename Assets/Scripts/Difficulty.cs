using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    // Difficulty Singleton

    public static Difficulty Instance { get; set; }
    public Difficulties currentDiff;

    string scene1 = "Scene1";
    string scene2 = "Scene2";
    string scene3 = "Scene3";
    string selectScenes = "SelectScenes";

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

    // load SelectScenes scene when ESC is pressed
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(selectScenes);
        }
    }

    // Difficulties enum
    public enum Difficulties
    {
        Easy, Medium, Hard
    }
    
    // set to easy
    public void Easy()
    {
        currentDiff = Difficulties.Easy;
        loadSelectedScene();
    }

    // set to medium
    public void Medium()
    {
        currentDiff = Difficulties.Medium;
        loadSelectedScene();
    }

    // set to hard
    public void Hard()
    {
        currentDiff = Difficulties.Hard;
        loadSelectedScene();
    }

    // load corresponding scene
    private void loadSelectedScene()
    {
        if (SelectScenes.Instance.currentScene == SelectScenes.Scenes.Scene1)
            SceneManager.LoadScene(scene1);
        else if (SelectScenes.Instance.currentScene == SelectScenes.Scenes.Scene2)
            SceneManager.LoadScene(scene2);
        else
            SceneManager.LoadScene(scene3);
    }
    
    // load SelectScenes scene
    public void Back()
    {
        SceneManager.LoadScene(selectScenes);
    }
}
