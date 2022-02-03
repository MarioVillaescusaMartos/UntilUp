using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    [SerializeField]
    private Text infoDisplay;

    [SerializeField]
    private GameObject loadCercleUI;

    public Button submitLogin;

    private string[] data;

    public void CallLogin()
    {
        StartCoroutine(Loging());
    }

    IEnumerator Loging()
    {
        /*WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);*/
        WWW www = new WWW("http://localhost/sqlconnect/login.php?name=" + usernameField.text + "&password=" + passwordField.text);
        yield return www;

        if (www.text[0] == '0')
        {
            DBManager.username = usernameField.text;
            data = www.text.Split("\t"[0]);

            SetDBManager();

            Debug.Log(DBManager.posX);

            System.GC.Collect();

            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            infoDisplay.text = "User identification failed. Error #" + www.text;

            HideLoad();
        }
    }

    public void VerifyInputs()
    {
        submitLogin.interactable = (usernameField.text.Length >= 1 && passwordField.text.Length >= 1);
    }

    public void SetDBManager()
    {
        DBManager.id = int.Parse(data[1]);
        DBManager.posX = int.Parse(data[2]) * 0.001f;
        DBManager.posY = int.Parse(data[3]) * 0.001f;
        DBManager.score = int.Parse(data[4]);
        DBManager.attempt = int.Parse(data[5]);
        DBManager.health = int.Parse(data[6]);
        DBManager.blasterbullet = int.Parse(data[7]);
        DBManager.laserbullet = int.Parse(data[8]);
    }

    public void ShowLoad()
    {
        loadCercleUI.SetActive(true);
    }

    public void HideLoad()
    {
        loadCercleUI.SetActive(false);
    }
}
