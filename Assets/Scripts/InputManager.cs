using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public UserInput playerInput;
    public UserInput.OnfootActions onfootActions;
    private PlayerMotor motor;
    PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new UserInput();
        onfootActions = playerInput.Onfoot;
        motor=GetComponent<PlayerMotor>();
        onfootActions.Jump.performed += Jump_performed;
        look=GetComponent<PlayerLook>();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        motor.ProcessMove(onfootActions.Move.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
      look.ProcessLook(onfootActions.Look.ReadValue<Vector2>());     
    }
    private void OnEnable()
    {
        onfootActions.Enable();
    }
    private void OnDisable()
    {
        onfootActions.Disable();
    }
}

