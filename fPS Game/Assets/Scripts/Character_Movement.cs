using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;//not rigidbody so no gravity is applied
    private Vector3 direction;
    //Jumping variables
    public float jumpForce;
    public float gravityIncrease;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal") * speed, direction.y, Input.GetAxisRaw("Vertical") * speed);

        if (controller.isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        

        direction.y = direction.y + Physics.gravity.y * gravityIncrease * Time.deltaTime;//applying gravity to the Y Axis only, can be edit in the project setting
        controller.Move(direction * Time.deltaTime);
    }
}
