using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private List<FryingRecipeSO> fryingRecipeSOList;

    private float fryingTimerProgress;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if(HasFryingRecipeSO(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
        }
        else
        {
            if(!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    private void Update()
    {
        if(HasKitchenObject())
        {
            fryingTimerProgress += Time.deltaTime;

            if(fryingTimerProgress >= 2.0f)
            {
                KitchenObjectSO outputFryingRecipeSO = GetOutputFromInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputFryingRecipeSO, this);

                fryingTimerProgress = 0;
            }


        }
    }

    public bool HasFryingRecipeSO(KitchenObjectSO inputKitchenObject)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObject);

        return fryingRecipeSO != null;
    }


    private KitchenObjectSO GetOutputFromInput(KitchenObjectSO inputKitchenObject)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObject);

        return fryingRecipeSO.output;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObject)
    {
        foreach(FryingRecipeSO fryingRecipeSO in fryingRecipeSOList)
        {
            if(fryingRecipeSO.input == inputKitchenObject)
            {
                return fryingRecipeSO;
            }
        }

        return null;
    }

}
