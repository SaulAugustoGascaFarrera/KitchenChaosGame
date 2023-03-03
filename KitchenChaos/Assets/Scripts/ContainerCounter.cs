using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter,IKitchenObjectParent
{

    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterToPoint;

    KitchenObject kitchenObject;

   

    public override void Interact(Player player)
    {
        if (kitchenObject == null)
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
