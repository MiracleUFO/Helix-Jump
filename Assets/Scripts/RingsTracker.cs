using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsTracker : MonoBehaviour
{
    private Transform player;
    private Transform player2;
    private Transform player3;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        player3 = GameObject.FindGameObjectWithTag("Player3").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (
            (transform.position.y > player.position.y) ||
            (transform.position.y > player2.position.y) ||
            (transform.position.y > player3.position.y)
            ) 
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
