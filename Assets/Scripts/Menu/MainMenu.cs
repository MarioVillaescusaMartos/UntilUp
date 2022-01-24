using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPlayGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1f;
    }

    public void PlayGameShow()
    {
        //SceneManager.LoadScene("GameScene");
        menuPlayGameUI.SetActive(true);
    }

    public void PlayGameNoShow()
    {
        menuPlayGameUI.SetActive(false);
    }
}
