using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField]
    private Game_Manager _gameManager;
    private Rigidbody2D ballRb;
    private Vector3 lastVelocity;
    [SerializeField]
    private Vector2 force = new Vector2(0, 0);
    [SerializeField]
    public float _speed = 100.0f;
    private int collisionCount = 0;

    [SerializeField]
    private GameObject Ball;
    private bool _wait = false;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        if(_gameManager == null)
        {
            Debug.LogError("Ball GameObject missing Game_Manager!");
        }

        ballRb = GetComponent<Rigidbody2D>();
        if(ballRb == null)
        {
            Debug.LogError("Ball GameObject missing Rigidbody2D!");
        }
    }

    public void StartBallMovement()
    {
        //0 = Left, 1 = Right
        int directionChoice = Random.Range(0, 2);
        Debug.Log("Direction Choice : " + directionChoice);
        switch(directionChoice)
        {
            case 0:
                force = new Vector2(Random.Range(-60.0f, 0f), Random.Range(-60.0f, 0f));
                ballRb.AddForce(force * _speed * Time.deltaTime, ForceMode2D.Impulse);
                break;
            case 1:
                force = new Vector2(Random.Range(0f, 60.0f), Random.Range(0f, 60.0f));
                ballRb.AddForce(force * _speed * Time.deltaTime, ForceMode2D.Impulse);
                break;
        }
    }

    void Update()
    {
        lastVelocity = ballRb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject != null)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collider.contacts[0].normal);
            ballRb.velocity = direction * Mathf.Max(speed, 0f);
            collisionCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player_1_Goal")
        {
            _gameManager.AddScore(1, 0);
            //Instantiate(Ball, new Vector3(0, 0, 0), Quaternion.identity);
            //Destroy(this.gameObject, 0.5f);
        }

        if (collider.gameObject.tag == "Player_2_Goal")
        {
            _gameManager.AddScore(1, 1);
            //Instantiate(Ball, new Vector3(0, 0, 0), Quaternion.identity);
            //Destroy(this.gameObject, 0.5f);
        }
        _wait = true;
        StartCoroutine(WaitForReposition());
    }

    private IEnumerator WaitForReposition()
    {
        while(_wait)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);

            yield return new WaitForSeconds(1.0f);
            transform.position = new Vector2(0, 0);
            _wait = false;

            //After we have waited 5 seconds print the time again.
            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }
    }
}
