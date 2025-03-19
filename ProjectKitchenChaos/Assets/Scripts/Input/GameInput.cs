using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPlayerInteract;
    public event EventHandler OnPlayerInteractAlternate;

    private InputManager inputManager;


    private void Awake()
    {
        inputManager = new InputManager();

        inputManager.Player.Enable();

        inputManager.Player.Interaction.performed += Interaction_performed;

        inputManager.Player.InteractionAlternate.performed += InteractionAlternate_performed;

        
    }

    private void InteractionAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerInteractAlternate?.Invoke(this, EventArgs.Empty);
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
