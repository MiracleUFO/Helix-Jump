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
        if (transform.position.y > player.position.y) {
            GameManager.noOfPassedRings++;
            Destroy(gameObject);
        }
    }
}
