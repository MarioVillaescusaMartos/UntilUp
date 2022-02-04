using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    private Text infoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGames()
    {
        if (DBManager.existsgame == 1)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            infoDisplay.text = "No game found";
        }
    }
}
