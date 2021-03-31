using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector3 lastVelocity;
    [SerializeField]
    private Vector2 force = new Vector2(0, 0);
    [SerializeField]
    public float _speed = 100.0f;
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        if(ballRb == null)
        {
            Debug.LogError("Ball GameObject missing Rigidbody2D!");
        }
        force = new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
        ballRb.AddForce(force * _speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = ballRb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject != null)
        {
            //if (collisionCount <= 0)
            //{
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);
                ballRb.velocity = direction * Mathf.Max(speed, 0f);
                collisionCount++;
            //}
            //else
            /*//{
                var speed = lastVelocity.magnitude * collisionCount;
                var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);
                ballRb.velocity = direction * Mathf.Max(speed, 0f);
                collisionCount++;
            }
            Debug.Log("Speed : " );*/
        }
    }
}
