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
        SceneManager.LoadScene("SignUpScene");
    }

    public void GoToSignIn() 
    {
        SceneManager.LoadScene("SignInScene");
    }
}
