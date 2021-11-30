using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public Button submitRegister;

    public void CallRegistration()
    {
        StartCoroutine(Registration());
    }

    IEnumerator Registration()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://sqlconnect.thekingred007.repl.co/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            SceneManager.LoadScene("LoginScene");
        }
        else
        {
            Debug.Log("User creation field. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitRegister.interactable = (usernameField.text.Length >= 1 && passwordField.text.Length >= 1);
    }
}
