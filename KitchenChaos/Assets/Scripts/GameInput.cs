using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;

    PlayerInputActions playerInputActions;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();


        playerInputActions.Player.Interact.performed += Interact_performed;

        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector2 GetMovementVerctorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();


        //if (Input.GetKey(KeyCode.W))
        //{
        //    inputVector.y += 1;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    inputVector.y -= 1;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    inputVector.x -= 1;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    inputVector.x += 1;
        //}



        inputVector = inputVector.normalized;

        return inputVector;
    }
}
