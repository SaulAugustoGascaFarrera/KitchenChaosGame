using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IKitchenObjectParent
{
    public static Player instace { get; private set; }

    //Events Delegates
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter baseCounter;
    }

    [Header("Player Properties")]
    [SerializeField] private Transform playerGrabPoint;
    [SerializeField] private float playerHeight = 2.0f;
    [SerializeField] private float playerRadius = 0.7f;

    [Header("Movement Properties")]
    [SerializeField] private float movementSpeed = 6.5f;
    [SerializeField] private float rotationSpeed = 7.5f;

   
    [SerializeField] private GameInput gameInput;

    [SerializeField] private KitchenObject kitchenObject;
    private BaseCounter baseCounter;
    private Vector3 lastDirection;

    private void Awake()
    {
        if(instace != null)
        {
            return;
        }

        instace = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnPlayerInteract += GameInput_OnPlayerInteract;
    }

    private void GameInput_OnPlayerInteract(object sender, EventArgs e)
    {
        if(baseCounter != null)
        {
            baseCounter.Interact(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        HandleInteraction();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementInput();

        Vector3 movementDirection = new Vector3(inputVector.x,0.0f,inputVector.y);


        float moveDistance = movementSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,movementDirection,moveDistance);


        if (canMove)
        {
            transform.position += movementDirection * movementSpeed * Time.deltaTime;
  
        }

        transform.forward = Vector3.Slerp(transform.forward, movementDirection, rotationSpeed * Time.deltaTime);

    }

    private void HandleInteraction()
    {
        Vector2 inputVector = gameInput.GetMovementInput();

        Vector3 movementDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);


        if(movementDirection != Vector3.zero)
        {
            lastDirection = movementDirection;
        }

        float interactionDistance = 0.85f;

        if (Physics.Raycast(transform.position, lastDirection, out RaycastHit hit, interactionDistance, 1 << 6))
        {
            if (hit.transform.TryGetComponent(out BaseCounter counter))
            {
                TrySetBaseCounter(counter);
            }
            else
            {
                TrySetBaseCounter(null);
            }
        }
        else
        {
            TrySetBaseCounter(null);
        }



    }

    public Transform GetFollowTransformPoint()
    {
        return playerGrabPoint;
    }

    public void SetKitchenObject(KitchenObject newKitchenObject)
    {
        kitchenObject = newKitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    private void TrySetBaseCounter(BaseCounter newBaseCounter)
    {
        this.baseCounter = newBaseCounter;

        OnSelectedCounterChanged.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            baseCounter = newBaseCounter
        });
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
}
