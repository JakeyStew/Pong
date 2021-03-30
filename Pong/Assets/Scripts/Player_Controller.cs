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

    void Start()
    {
        //Gets the boundaries of the camera view.
        _screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        //Gets the hieght of the seletced game object
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        if (gameObject.tag == "Player") { 
            //Get input for vertical movement
            float verticalInput = Input.GetAxis("Vertical");

            //Set the movement speed and axis
            var movement = new Vector3(0, verticalInput, 0) * _moveSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + objectHeight, _screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
