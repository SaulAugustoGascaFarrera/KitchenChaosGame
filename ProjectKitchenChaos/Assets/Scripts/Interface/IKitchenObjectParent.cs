using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform GetFollowTransformPoint();

    public void SetKitchenObject(KitchenObject newKitchenObject);

    public KitchenObject GetKitchenObject();

    public bool HasKitchenObject();

    public void ClearKitchenObject();


}
