using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
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
