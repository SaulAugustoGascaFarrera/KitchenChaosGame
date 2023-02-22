using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; set; }

    [Header("Player Stats")]
    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 7.0f;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVerctorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);


        float maxDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2.0f;

        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,moveDirection,maxDistance);

        if(canMove)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;


            float rotateSpeed = 10.0f;

            transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        }
        
    }
}
