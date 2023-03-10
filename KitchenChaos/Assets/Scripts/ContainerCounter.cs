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
       
        if(!player.HasKitchenObhject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            //Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab);
            //kitchenObjectTranform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
            
      
    }

   
}
