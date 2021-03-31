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

    private bool _canStart = true;
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _ballController = GameObject.Find("Ball").GetComponent<Ball_Controller>();
        //Gets the boundaries of the camera view.
        _screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        //Gets the hieght of the seletced game object
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _canStart == true) 
        {
            _uiManager.StartGame();
            _ballController.StartBallMovement();
            _canStart = false;
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
