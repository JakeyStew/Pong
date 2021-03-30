using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector3 lastVelocity;
    [SerializeField]
    private Vector2 force = new Vector2(5.0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        if(ballRb == null)
        {
            Debug.LogError("Ball GameObject missing Rigidbody2D!");
        }
        ballRb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = ballRb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Collision : " + collider);
        if(collider.gameObject != null)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);
            ballRb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}
