using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } //get sirve para obtener/set para asignar
    public float ver { get; private set; }

    public event Action OnFire = delegate { }; //Se crea el evento pulico para que hayan clases que se puedan enterar de el (OnFire puede ser cualquier nombre)(delegate: forma de decir que es un evento)
    public event Action OnPause = delegate { };

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            OnFire();//Cuando se pulsa la tecla se llama al evento y se avisan a as clases suscritas
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause(); //Cuando se pulsa la tecla "Esc" el juego se pausa
        }
    }
}