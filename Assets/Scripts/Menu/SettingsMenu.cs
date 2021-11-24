using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{ 
    [SerializeField]
    private GameObject gameSettingsUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnterSettings()
    {
        gameSettingsUI.SetActive(true);
    }

    public void ExitSettings()
    {
        gameSettingsUI.SetActive(false);
    }
}
