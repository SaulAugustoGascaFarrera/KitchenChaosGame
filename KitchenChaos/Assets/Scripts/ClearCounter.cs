using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [Header("Clear Counter Atts")]
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing = false;
    public override void Interact(Player player)
    {
        if(!HasKitchenObhject())
        {
            if(player.HasKitchenObhject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carrying anything
            }
            
        }
        else
        {
            //there is a kitchen object here

            if (player.HasKitchenObhject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    } 
}


