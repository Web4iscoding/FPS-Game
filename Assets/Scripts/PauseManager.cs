using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // PauseManager Singleton

    public GameObject pauseMenu;
    public GameObject generalUI;
    public bool isPaused;

    public static PauseManager Instance { get; set; }

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

    // pause or resume according to key pressed
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape))
            Resume();        
    }

    // pause
    public void Pause() {
        pauseMenu.SetActive(true);
        generalUI.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    // resume
    public void Resume() {
        pauseMenu.SetActive(false);
        generalUI.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    // load menu scene
    public void backToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
