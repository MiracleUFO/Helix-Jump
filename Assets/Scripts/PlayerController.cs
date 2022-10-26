using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6.0f;

    private AudioManager audioManager;

    public GameObject explosionFx;


    void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        audioManager.Play("bounce");

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Unsafe (Instance)")
        {
            if (GameManager.noOfHearts <= 0) {
                audioManager.Play("gameover");
                GameManager.gameOver = true;
            } else 
                GameManager.noOfHearts--;
        } else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            //  Show fireworks when player clears level
            Vector3 newExplosionPos = new Vector3(explosionFx.transform.position.x, -50, explosionFx.transform.position.z);
            Instantiate(explosionFx, newExplosionPos, explosionFx.transform.rotation);

            audioManager.Play("winlevel");
            GameManager.levelCompleted = true;
        }
    }
}
