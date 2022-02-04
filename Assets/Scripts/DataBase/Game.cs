using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text idDisplay;

    public GameObject characterPosition;

    [SerializeField]
    private Text infoDisplay;

    private int gettedposX;
    private int gettedposY;

    private void Awake()
    {
        
    }

    public void CallSaveData()
    {
        DBManager.posX = DBManager.posX * 1000f;
        DBManager.posY = DBManager.posY * 1000f;

        gettedposX = (int)DBManager.posX;
        gettedposY = (int)DBManager.posY;

        StartCoroutine(SavePlayerData());
        
        Debug.Log("X: Getted: " + gettedposX + "Real:  " + DBManager.posX);
        Debug.Log("Y: Getted: " + gettedposY + "Real:  " + DBManager.posY);
    }

    IEnumerator SavePlayerData()
    {
        

        /*WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("id", DBManager.id);
        form.AddField("posX", gettedposX);
        form.AddField("posY", gettedposY);
        form.AddField("score", DBManager.score);
        form.AddField("attempt", DBManager.attempt);
        form.AddField("health", DBManager.health);
        form.AddField("blasterbullet", DBManager.blasterbullet);
        form.AddField("laserbullet", DBManager.laserbullet);*/

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php?name=" + DBManager.username + "&id=" + DBManager.id + "&posX=" + gettedposX + "&posY=" + gettedposY +
                "&score=" + DBManager.score + "&attempt=" + DBManager.attempt + "&health=" + DBManager.health + "&blasterbullet=" + DBManager.blasterbullet + "&laserbullet=" + DBManager.laserbullet + "&existsgame=1");
        yield return www;
        if (www.text == "0")
        {
            infoDisplay.text = "Game Saved!";

            Debug.Log("Game saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }

    }
}
