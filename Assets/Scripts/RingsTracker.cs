using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsTracker : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y) 
        {
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.noOfPassedRings++;

            //  If game started is not set to true (user has not interacted with UI yet) but the PLAYER has passed a ring, set is game started to true
            if (!GameManager.isGameStarted)
                GameManager.isGameStarted = true;
            
            GameManager.score += 2;
            Destroy(gameObject);
        }
    }
}
