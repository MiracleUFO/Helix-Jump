using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 150.0f;
    private bool fingerMoved;
    
    void Update()
    {
        if (!GameManager.isGameStarted)
            return;
        
        // For PC & Mobile
        fingerMoved = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0);
        if (fingerMoved) {
            float xMove = Input.touchCount > 0 ? Input.GetTouch(0).deltaPosition.x : Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -xMove * rotationSpeed * Time.deltaTime, 0);
        }
    }
}
