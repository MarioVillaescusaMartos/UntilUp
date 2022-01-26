using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOversUI;

    [SerializeField]
    private Toggle toggleUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TryAgain()
    {
        gameOversUI.SetActive(false);

        Time.timeScale = 1f;

        GameOverManager.notShowGameOver = toggleUI.isOn;
    }
}
