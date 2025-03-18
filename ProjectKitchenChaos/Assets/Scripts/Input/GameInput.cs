using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPlayerInteract;

    private InputManager inputManager;


    private void Awake()
    {
        inputManager = new InputManager();

        inputManager.Player.Enable();

        inputManager.Player.Interaction.performed += Interaction_performed;

        
    }

    private void Interaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerInteract?.Invoke(this, EventArgs.Empty);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector2 GetMovementInput()
    {
        Vector2 inputMovement = inputManager.Player.Move.ReadValue<Vector2>();

        inputMovement = inputMovement.normalized;

        return inputMovement;
    }
}
