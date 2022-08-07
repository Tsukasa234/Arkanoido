using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed, bounds = 4.5f;

    private float getInput;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        getInput = Input.GetAxisRaw("Horizontal");

        // transform.Translate();

        Vector2 playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(playerPosition.x + getInput * speed * Time.deltaTime, -bounds, bounds);

        transform.position = playerPosition;
    }
}
