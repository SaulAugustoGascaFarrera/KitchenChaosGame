using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] KitchenObjectSO CutKitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObhject())
        {
            if (player.HasKitchenObhject())
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

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObhject())
        {
            //There is a kitchen object here
            GetKitchenObject().DestroySelf();


            KitchenObject.SpawnKitchenObject(CutKitchenObjectSO, this);
            //Transform kitchenObjectTransform = Instantiate(CutKitchenObjectSO.prefab);
            //kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
    }


}
