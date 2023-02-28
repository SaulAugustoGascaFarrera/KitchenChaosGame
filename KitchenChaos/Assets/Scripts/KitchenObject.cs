using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [Header("Kitchen Object Stats")]
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    ClearCounter clearCounter;
    IKitchenObjectParent kitchenObjectParent;

   public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }


    public void SetOnClearCounter(ClearCounter clearCounter)
    {

        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObhject();
        }


        this.clearCounter = clearCounter;


        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetOnClearCounter()
    {
        return clearCounter;
    }


    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObhject();
        }


        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObhject())
        {
            Debug.Log("kitchenObjectParent already has a kitchen object");
        }


        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;

    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

}
