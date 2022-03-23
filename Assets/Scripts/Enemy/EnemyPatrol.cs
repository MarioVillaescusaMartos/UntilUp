using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform viewpoint;
    [SerializeField]
    private float length;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float speed;

    private SpriteRenderer _sp;
    private Rigidbody2D _rb;
    public RaycastHit2D hit;

    private void Awake()
    {
        _sp = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
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
            hit = Physics2D.Raycast(viewpoint.position, Vector2.left + Vector2.down, length, groundLayer);

            if (!hit.collider)
            {
                _sp.flipX = false;
            }
            else
            {
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);

                Debug.Log("speed");
            }
        }
        else
        {
            hit = Physics2D.Raycast(viewpoint.position, Vector2.right + Vector2.down, length, groundLayer);

            if (!hit.collider)
            {
                _sp.flipX = true;
            }
            else
            {
                _rb.velocity = new Vector2(speed, _rb.velocity.y);

                Debug.Log("speed");
            }
        }

        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(viewpoint.position, viewpoint.position + Vector3.right + Vector3.down * length);
    }
}