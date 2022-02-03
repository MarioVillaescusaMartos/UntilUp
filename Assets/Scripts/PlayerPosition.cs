using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(DBManager.posX, DBManager.posY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        DBManager.posX = transform.position.x;
        DBManager.posY = transform.position.y;
    }
}
