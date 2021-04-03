using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField]
    private Game_Manager _gameManager;
    private Rigidbody2D _ballRb;
    private Vector3 _lastVelocity;
    [SerializeField]
    private Vector2 _forceDirection = new Vector2(0, 0);
    [SerializeField]
    public float _speed = 100.0f;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        if(_gameManager == null)
        {
            Debug.LogError("Ball GameObject missing Game_Manager!");
        }

        _ballRb = GetComponent<Rigidbody2D>();
        if(_ballRb == null)
        {
            Debug.LogError("Ball GameObject missing Rigidbody2D!");
        }
    }

    public void StartBallMovement()
    {
        int directionChoice = Random.Range(0, 2);   //0 = Left, 1 = Right
        switch(directionChoice)
        {
            case 0:
                float degrees = Random.Range(110, 160);
                float radians = degrees * Mathf.Deg2Rad;

                float x = Mathf.Cos(radians);
                float y = Mathf.Sin(radians);

                Vector2 angle = new Vector2(x, y);

                _forceDirection = angle;
                _ballRb.AddForce(_forceDirection * _speed * Time.deltaTime, ForceMode2D.Impulse);

                Debug.Log("Degrees : " + degrees);
                Debug.Log("Radians : " + radians);
                Debug.Log("X : " + x);
                Debug.Log("Y : " + y);
                Debug.Log("Angle : " + angle);
                break;
            case 1:
                degrees = Random.Range(70, 20);
                radians = degrees * Mathf.Deg2Rad;

                x = Mathf.Cos(radians);
                y = Mathf.Sin(radians);

                angle = new Vector2(x, y);

                _forceDirection = angle;
                _ballRb.AddForce(_forceDirection * _speed * Time.deltaTime, ForceMode2D.Impulse);

                Debug.Log("Degrees : " + degrees);
                Debug.Log("Radians : " + radians);
                Debug.Log("X : " + x);
                Debug.Log("Y : " + y);
                Debug.Log("Angle : " + angle);
                break;
        }
    }

    void Update()
    {
        _lastVelocity = _ballRb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject != null)
        {
            var speed = _lastVelocity.magnitude;
            var direction = Vector3.Reflect(_lastVelocity.normalized, collider.contacts[0].normal);
            _ballRb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player_1_Goal")
        {
            _gameManager.AddScore(1, "Player One");
        }

        if (collider.gameObject.tag == "Player_2_Goal")
        {
            _gameManager.AddScore(1, "Player Two");
        }
    }
}
