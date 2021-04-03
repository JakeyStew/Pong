using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    float _moveSpeed = 100;
    private Vector2 _screenBounds;
    private float objectHeight;

    private UI_Manager _uiManager;
    private Ball_Controller _ballController;

    private bool _canStart = false;
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _ballController = GameObject.Find("Ball").GetComponent<Ball_Controller>();
        if (_uiManager == null)
        {
            Debug.LogError("Player_Controller missing UI_Manager!");
        }
        if (_ballController == null)
        {
            Debug.LogError("Player_Controller missing Ball_Controller!");
        }

        _screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        _canStart = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _canStart) 
        {
            _canStart = false;
            _uiManager.StartGame();
            _ballController.StartBallMovement();
        }
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        if (gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
            }
        }

        if (gameObject.tag == "Player 2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + objectHeight, _screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
