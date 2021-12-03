using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignOff : MonoBehaviour
{
    public void CallSigningOff()
    {
        StartCoroutine(SigningOff());
        
    }

    IEnumerator SigningOff()
    {
        yield return DBManager.username;

        DBManager.LogOut();

        if (DBManager.username == null)
        {
            SceneManager.LoadScene("SignInScene");
        }
    }
}
