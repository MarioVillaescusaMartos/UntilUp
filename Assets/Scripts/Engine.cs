using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpSpeed;

    private InputSystemKeyboard _inputSystem;
    private SpriteRenderer _sp;

    void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _inputSystem.ver * transform.up * jumpSpeed * Time.deltaTime;
        transform.position += _inputSystem.hor * transform.right * speed * Time.deltaTime;

        if (_inputSystem.hor > 0)
        {
            _sp.flipX = false;
            
        }
        else if (_inputSystem.hor < 0)
        {            
            _sp.flipX = true;            
        }
    }
}