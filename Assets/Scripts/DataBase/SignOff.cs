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

        Debug.Log(DBManager.username);

        DBManager.existsgame = 0;
        DBManager.LogOut();


        if (DBManager.username == null)
        {
            SceneManager.LoadScene("SignInScene");
            Debug.Log(DBManager.username);

        }
    }
}
