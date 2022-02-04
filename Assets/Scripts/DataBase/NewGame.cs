using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGame : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGames()
    {
        StartCoroutine(NewGameEntry());
    }

    IEnumerator NewGameEntry()
    {
        /*WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("id", DBManager.id);
        form.AddField("posX", positionX.ToString());
        form.AddField("posY", positionY.ToString());
        form.AddField("score", 0);
        form.AddField("attempt", 0);
        form.AddField("health", 1);
        form.AddField("blasterbullet", 5);
        form.AddField("laserbullet", 5);*/
        WWW www = new WWW("http://localhost/sqlconnect/savedata.php?name="+DBManager.username+"&id="+DBManager.id+"&posX=-7640"+"&posY=-2667"+
                            "&score=0"+"&attempt=0"+"&health=1"+"&blasterbullet=5"+"&laserbullet=5"+"&existsgame=1");
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("New Game Created");

            System.GC.Collect();
    
            DBManager.existsgame = 1;

            SceneManager.LoadScene("IntroduceStoryScene");
        }
        else
        {
            Debug.Log("User creation field. Error #" + www.text);
        }
    }
}
