using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look : MonoBehaviour
{
    [SerializeField] private string lookX;
    [SerializeField] private string lookY;
    [SerializeField] private float sensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();//make sure the cursor is at the center of the screen when the level first load
        xAxisClamp = 0f;
    }

    private void LockCursor()//lock the cursor to the center of the screen
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()//for roataing the player camera
    {
        float mouseX = Input.GetAxis(lookX) * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(lookY) * sensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        if(xAxisClamp >= 90f)//makes sure the player can't rotate 180 degrees on Y axis
        {
            xAxisClamp = 90f;
            mouseY = 0f;
            ClampRotation(270f);//camera is at 270 degrees when looking straight upward
        }
        else if (xAxisClamp < -90f)//makes sure the player can't rotate 180 degrees on Y axis
        {
            xAxisClamp = -90f;
            mouseY = 0f;
            ClampRotation(90f);//camera is at 90 degrees when looking straight downward
        }

        transform.Rotate(Vector3.left * mouseY);//move the camera up and down
        playerBody.Rotate(Vector3.up * mouseX);//move the camera right and left
    }

    private void ClampRotation(float value)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.x = value;
        transform.eulerAngles = rotation;
    }

}
