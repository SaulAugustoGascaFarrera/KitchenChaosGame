using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class TestPlayer : MonoBehaviour
{

    [SerializeField] GameInput gameInput;
    [SerializeField] private LayerMask _testLayerMask;
    Vector3 lastInteractionDirection;
    [SerializeField] bool collisioned = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }


    void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVerctorNormalized();


        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);



        transform.position += moveDirection * 7.0f * Time.deltaTime;
    }


    void HandleInteraction()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }


        inputVector = inputVector.normalized;


        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDirection != Vector3.zero) lastInteractionDirection = moveDirection;


        RaycastHit hit;

        bool intercated = Physics.Raycast(transform.position, lastInteractionDirection, out hit, 2.0f, _testLayerMask);


        if (intercated)
        {
            Debug.Log(hit.collider.name);
            collisioned = true;
        }
    }



}
