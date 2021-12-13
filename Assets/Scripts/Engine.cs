using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour
{
    private float speed;
    private bool secondJump;

    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private Transform groundChecker;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask groundMask;

    private InputSystemKeyboard _inputSystem;
    private SpriteRenderer _sp;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _sp = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputSystem.OnJump += Jumping; 
    }

    private void OnDisable()
    {
        _inputSystem.OnJump -= Jumping;
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
    }

    public void GetSpeed(float speedGet)
    {
        speed = speedGet;
    }

    public void Jumping()
    {
        bool t = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);
        if (t)
        {
            secondJump = true;
        }

        if (t)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
        else if (secondJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            secondJump = false;
        }
    }
}