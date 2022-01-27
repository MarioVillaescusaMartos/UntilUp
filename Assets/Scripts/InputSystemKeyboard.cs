using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } //get sirve para obtener/set para asignar
    public float ver { get; private set; }
    //public bool w { get; private set; }

    public event Action OnFire1 = delegate { }; //Se crea el evento pulico para que hayan clases que se puedan enterar de el (OnFire puede ser cualquier nombre)(delegate: forma de decir que es un evento)
    public event Action OnFire2 = delegate { };
    public event Action OnPause = delegate { };
    public event Action OnJump = delegate { };
    public event Action OnTp = delegate { };

    public string keyPressed;

    private bool pause;
    private bool gameOver;

    // Update is called once per frame
    private void Update()
    {
        pause = PauseManager.pauseMode;

        if (!pause)
        {
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Fire1"))
            {
                OnFire1();//Cuando se pulsa la tecla izquierda del ratón el jugador dispara
            }

            if (Input.GetButtonDown("Fire2"))
            {
                OnFire2();//Cuando se pulsa la tecla derecha del ratón el jugador dispara
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnTp();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                OnJump(); //Cuando se pulsa la tecla "W" el personaje principal salta, y si se le pulsa una segunda vez salta otra vez en el aire
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPause(); //Cuando se pulsa la tecla "Esc" el juego se pausa
            }
        }
    }

    public string ReturnKey()
    {
        return keyPressed;
    }
}