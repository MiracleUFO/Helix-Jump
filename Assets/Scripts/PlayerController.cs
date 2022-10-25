using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6.0f;
    private void OnCollisionEnter(Collision collision) {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)") {

        } else if (materialName == "Unsafe (Instance)") {
            GameManager.gameOver = true;
        } else if (materialName == "LastRing (Instance)") {
            GameManager.levelCompleted = true;
        }
    }
}
