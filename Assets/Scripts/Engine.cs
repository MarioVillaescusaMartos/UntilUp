using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour
{
    private float speed;
    private bool secondJump;
    public bool checkGround;

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

    public event Action OnJumped = delegate { };

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
        checkGround = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);

        if (checkGround)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            secondJump = true;

            OnJumped();
        }
        else if (secondJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            secondJump = false;

            OnJumped();
        }
    }
}