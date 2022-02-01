using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicSounds : MonoBehaviour
{
    /*public Transform gameManager;

    GameManager gameManagerC;*/

    // Start is called before the first frame update
    void Start()
    {
        //gameManagerC = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameManagerC.IsCinematicMode()) { return; }
    }
    public void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }

}
