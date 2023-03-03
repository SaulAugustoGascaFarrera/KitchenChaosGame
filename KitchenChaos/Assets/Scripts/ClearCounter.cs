using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{


    [Header("Clear Counter Atts")]
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(testing && Input.GetKeyDown(KeyCode.T))
        //{
        //    if(kitchenObject != null)
        //    {
        //        //kitchenObject.SetOnClearCounter(secondClearCounter);
        //        kitchenObject.SetKitchenObjectParent(secondClearCounter);
        //    }
        //}
    }


    public override void Interact(Player player)
    {
        
    }

    
}


