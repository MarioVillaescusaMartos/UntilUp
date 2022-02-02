using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    [SerializeField]
    private Text infoDisplay;

    [SerializeField]
    private GameObject loadCercleUI;

    private float positions;

    public Button submitRegister;

    public void CallRegistration()
    {
        StartCoroutine(Registration());
    }

    IEnumerator Registration()
    {
        //string sqcon = "URI = file:" + Application.dataPath + "/sqlconnect/register.db";
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("posX", positions.ToString());
        form.AddField("posY", positions.ToString());
        form.AddField("score", 0);
        form.AddField("attempt", 0);
        form.AddField("health", 1);
        form.AddField("blasterbullet", BlasterSystem.bullets);
        form.AddField("laserbullet", LaserSystem.bullets);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created successfully.");

            System.GC.Collect();

            SceneManager.LoadScene("SignInScene");
        }
        else
        {
            infoDisplay.text = "User identification failed. Error #" + www.text;

            HideLoad();

            //Debug.Log("User creation field. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitRegister.interactable = (usernameField.text.Length >= 1 && passwordField.text.Length >= 1);
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
