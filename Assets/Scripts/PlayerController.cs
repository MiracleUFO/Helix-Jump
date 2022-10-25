using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6.0f;

    private AudioManager audioManager;

    void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        audioManager.Play("bounce");

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)") 
        {

        } else if (materialName == "Unsafe (Instance)") 
        {
            audioManager.Play("gameover");
            GameManager.gameOver = true;
        } else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted) 
        {
            audioManager.Play("winlevel");
            GameManager.levelCompleted = true;
        }
    }
}
