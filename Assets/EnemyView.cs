using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private Transform viewpoint;
    [SerializeField]
    private float lenght;
    [SerializeField]
    private LayerMask LayerPlayer;
    [SerializeField]
    public RaycastHit2D hit;

    private SpriteRenderer _sp;

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
        if (_sp.flipX == true)
        {
            hit = Physics2D.Raycast(viewpoint.position, Vector2.right, -lenght, LayerPlayer);
        }
        else //!_sp.flipX
        {
            hit = Physics2D.Raycast(viewpoint.position, Vector2.right, lenght, LayerPlayer);
        }


        if (hit.collider != null)
        {
            OnView();
        }
    }

    private void OnDrawGizmos()
    {
            Debug.DrawLine(viewpoint.position, viewpoint.position + Vector3.right * -lenght);
    }
}
