using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text idDisplay;
    public Text scoreDisplay;
    public Text healthDisplay;

    [SerializeField]
    private Text infoDisplay;

    public int score = 3;

    private void Awake()
    {
        playerDisplay.text = "Player: " + DBManager.username;
        idDisplay.text = "ID: " + DBManager.id;
        scoreDisplay.text = "Score: " + score;
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
        form.AddField("score", ScoreSystem.score);
        form.AddField("attempt", AttemptSystem.attempt);
        form.AddField("health", HealthSystem.health);
        form.AddField("blasterbullet", BlasterSystem.bullets);
        form.AddField("laserbullet", LaserSystem.bullets);

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
