using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    // SelectScenes Singleton

    string difficulty = "Difficulty";
    string selectMode = "SelectMode";


    public static SelectScenes Instance { get; set; }
    public SelectScenes.Scenes currentScene;

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

    // load SelectMode scene when ESC is pressed
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(selectMode);
        }
    }

    // Scenes enum
    public enum Scenes
    {
        Scene1, Scene2, Scene3
    }

    // assign selected select to public variable currentScene and load Difficulty scene
    public void Scene1()
    {
        currentScene = Scenes.Scene1;
        SceneManager.LoadScene(difficulty);
    }

    // assign selected select to public variable currentScene and load Difficulty scene
    public void Scene2()
    {
        currentScene = Scenes.Scene2;
        SceneManager.LoadScene(difficulty);
    }

    // assign selected select to public variable currentScene and load Difficulty scene
    public void Scene3()
    {
        currentScene = Scenes.Scene3;
        SceneManager.LoadScene(difficulty);
    }

    // load SelectMode scene
    public void Back()
    {
        SceneManager.LoadScene(selectMode);
    }
}
