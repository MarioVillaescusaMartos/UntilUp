using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignOnSignInOptions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToSignUp()
    {
        System.GC.Collect();

        SceneManager.LoadScene("SignUpScene");
    }

    public void GoToSignIn() 
    {
        System.GC.Collect();

        SceneManager.LoadScene("SignInScene");
    }
}
