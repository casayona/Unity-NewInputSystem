using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInputs playerInputs;


    private void Awake()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();

        playerInputs.Player.Jump.performed += PlayerJump;
    }

    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            PlayerMovement.instance.HandleJump();
        }
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();


        return inputVector;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
