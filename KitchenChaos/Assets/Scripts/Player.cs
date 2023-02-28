using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Rendering;

public class Player : MonoBehaviour , IKitchenObjectParent
{

    public static Player Instance { get; set; }

    [Header("Player Stats")]
    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 7.0f;
    [SerializeField] float interactDistance = 2.5f;
    [SerializeField] Transform kitchenObjectHoldPoint;

    [Header("Counter Stats")]
    ClearCounter selectedCounter;
    Vector3 lastInteractDirection;
    [SerializeField] LayerMask countersLayerMask;
    [SerializeField] LayerMask testLayerMask;

    [Header("Kitchen Object Stats")]
    KitchenObject kitchenObject;

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one player instance");
        }

        Instance = this;
    }


    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInteractions();
        
    }


    void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVerctorNormalized();

        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);


        float maxDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2.0f;

        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,moveDirection,maxDistance);


        if(!canMove)
        {
            //Cannot move towards direction

            //attempts only x axis
            Vector2 moveDirX = new Vector3(moveDirection.x, 0, 0).normalized;

            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, maxDistance);

            if(canMove)
            {
                moveDirection = moveDirX;
            }
            else
            {
                //cannot move onluy in x axis

                //attempt only in the z axis
                Vector2 moveDirZ = new Vector3(0, 0, moveDirection.z).normalized;

                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, maxDistance);

                if (canMove)
                {
                    //can move only in the z axis
                    moveDirection = moveDirZ;
                }
                else
                {
                    //cannot move in any direction
                }
            }

           

        }




        if(canMove)
        {
            transform.position += moveDirection * maxDistance;


            float rotateSpeed = 10.0f;

            transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

           
        }
        
    }


    void HandleInteractions()
    {

        Vector2 inputVector = gameInput.GetMovementVerctorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        if (moveDirection != Vector3.zero) lastInteractDirection = moveDirection;

        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, lastInteractDirection, out raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                //clearCounter.Interact();
                if (clearCounter != selectedCounter)
                {
                    //selectedCounter = clearCounter;

                    SetSelectedCounter(clearCounter);

                    //OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
                    //{
                    //    selectedCounter = selectedCounter
                    //});
                }
                //clearCounter.Interact();
            }
            else
            {
                SetSelectedCounter(null);
            }

        }
        else
        {
            SetSelectedCounter(null);
        }
    }


    void HandleIT()
    {
        Vector2 inputVector = gameInput.GetMovementVerctorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        //if (moveDirection != Vector3.zero) lastInteractDirection = moveDirection;

        float interactDistance = 2.0f;

        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, moveDirection, out raycastHit, interactDistance, testLayerMask))
        {

            Debug.Log("COLISIONEEEE");

        }
    }


    #region Counter Functions

    void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        }); ;

    }


    void SetSelectedCounterTest()
    {
        

        //OnSelectedCounterChanged?.Invoke(this, EventArgs.Empty);

    }



    #endregion


    #region Kitchen Object Interface Functions


    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObhject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObhject()
    {
        return kitchenObject != null;
    }

    #endregion

}
