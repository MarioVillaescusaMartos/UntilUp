using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour
{
    private float speed;

    [SerializeField]
    private float jumpSpeed;

    private InputSystemKeyboard _inputSystem;
    private SpriteRenderer _sp;
    private Rigidbody2D _rb;

    void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _sp = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position += _inputSystem.ver * transform.up * jumpSpeed * Time.deltaTime;
        transform.position += _inputSystem.hor * transform.right * speed * Time.deltaTime;*/

        _rb.velocity = new Vector2(_inputSystem.hor * speed, _rb.velocity.y);


        if (_inputSystem.hor > 0)
        {
            _sp.flipX = false;
            
        }
        else if (_inputSystem.hor < 0)
        {            
            _sp.flipX = true;            
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            
        }
    }

    public void GetSpeed(float speedGet)
    {
        speed = speedGet;
    }
}