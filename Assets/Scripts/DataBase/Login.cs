using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public Button submitLogin;

    public void CallLogin()
    {
        StartCoroutine(Loging());
    }

    IEnumerator Loging()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://sqlconnect.thekingred007.repl.co/login.php", form);
         yield return www;

        if (www.text[0] == '0')
        {
            DBManager.username = usernameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("User identification failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitLogin.interactable = (usernameField.text.Length >= 1 && passwordField.text.Length >= 1);
    }
}
