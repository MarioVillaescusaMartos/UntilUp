using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputSystemKeyboard _inputSystem;

    private static bool gameIsPaused;

    [SerializeField]
    private GameObject gamePauseUI;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }

    private void OnEnable()
    {
        _inputSystem.OnPause += PauseOn;
    }

    private void OnDisable()
    {
        _inputSystem.OnPause -= PauseOn;
    }

    // Update is called once per frame
    void Update()
    {
        PauseManager.pauseMode = gameIsPaused;
    }

    void PauseOn()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        gamePauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        gamePauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}