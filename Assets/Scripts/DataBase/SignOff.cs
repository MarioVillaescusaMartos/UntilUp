using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOff : MonoBehaviour
{
    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SignInScene");
        }
    }

    public void SigningOff()
    {
        DBManager.LogOut();
    }
}
