using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 playerVelocity;
    public float playerSpeed = 5.0f;

    bool isGrounded;
    float speed = 5f;
    float gravity = -10f;
    float jumpHeight = -9f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>();
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
      //var mouseX=  Input.GetAxis("Mouse X");
       Debug.Log(input.ToString());

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x= input.x;   
        moveDirection.z= input.y;   

        controller.Move(transform.TransformDirection(moveDirection)*playerSpeed*Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y<0)
        {
            playerVelocity.y = -0f;
        }

     //   Debug.Log(playerVelocity.y*Time.deltaTime);
       controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * gravity);
        }
    }
}
