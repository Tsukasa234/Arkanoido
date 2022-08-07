using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier = 1.05f;
    private bool ballIsMoving;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !ballIsMoving)
        {
            transform.parent = null;
            rb.velocity = initialVelocity;
            ballIsMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Block"))
        {
            Destroy(other.gameObject);
            rb.velocity *= velocityMultiplier;
            GameManager.sharedInstance.BlockDestroy();
        }
        else if(other.gameObject.CompareTag("Restart")){
            GameManager.sharedInstance.ReloadScene();
        }
    }
}
