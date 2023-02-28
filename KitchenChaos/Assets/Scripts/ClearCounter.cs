using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{


    [Header("Clear Counter Atts")]
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterToPoint;
    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing = false;

    KitchenObject kitchenObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                //kitchenObject.SetOnClearCounter(secondClearCounter);
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }


    public void Interact(Player player)
    {
        if(kitchenObject == null)
        {
            Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab, counterToPoint);
            //kitchenObjectTranform.localPosition = Vector3.zero;


            //kitchenObject = kitchenObjectTranform.GetComponent<KitchenObject>();
            //kitchenObject.SetOnClearCounter(this);

            //kitchenObjectTranform.GetComponent<KitchenObject>().SetOnClearCounter(this);
            kitchenObjectTranform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterToPoint;
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
}


