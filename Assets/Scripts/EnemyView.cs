using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private Transform viewpoint;
    [SerializeField]
    private float length;
    [SerializeField]
    private LayerMask playerLayer;

    private SpriteRenderer _sp;
    public RaycastHit2D hit;

    public event Action OnView = delegate { };

    private void Awake()
    {
        _sp = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_sp.flipX)
        {
            hit = Physics2D.Raycast(viewpoint.position, Vector2.left, length, playerLayer);
        }
        else
        {
            hit = Physics2D.Raycast(viewpoint.position, Vector2.right, length, playerLayer);
        }

        if (hit.collider)
        {
            OnView();
        }
    }

    private void OnDrawGizmos()
    {    
        Debug.DrawLine(viewpoint.position, viewpoint.position + Vector3.left * length);
    }

    public bool ReturnHit()
    {
        return hit.collider;
    }
}