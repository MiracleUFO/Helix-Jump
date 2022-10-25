using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6.0f;
    private void OnCollisionEnter(Collision collision) {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        Debug.Log(collision.transform.GetComponent<MeshRenderer>().material.name);
    }
}
