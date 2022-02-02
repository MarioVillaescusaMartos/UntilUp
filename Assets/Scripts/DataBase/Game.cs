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

    private void Awake()
    {
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("id", DBManager.id);
        form.AddField("posX", DBManager.posX.ToString());
        form.AddField("posY", DBManager.posY.ToString());
        form.AddField("score", DBManager.score);
        form.AddField("attempt", DBManager.attempt);
        form.AddField("health", DBManager.health);
        form.AddField("blasterbullet", DBManager.blasterbullet);
        form.AddField("laserbullet", DBManager.laserbullet);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
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
