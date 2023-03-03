using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] KitchenObjectSO kitchenObjectSO;
   
    public override void Interact(Player player)
    {
       
            Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab);
            //kitchenObjectTranform.localPosition = Vector3.zero;


            //kitchenObject = kitchenObjectTranform.GetComponent<KitchenObject>();
            //kitchenObject.SetOnClearCounter(this);

            //kitchenObjectTranform.GetComponent<KitchenObject>().SetOnClearCounter(this);
            kitchenObjectTranform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
      
    }

   
}
