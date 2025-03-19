using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler OnCut;

    [SerializeField] private List<CuttingRecipeSO> cuttingRecipeSOList;

    [SerializeField] private int cuttingProgress;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
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

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject() && !player.HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingProgress++;

            CuttingRecipeSO cuttingRecipeSO = GetCuttingCounterWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnCut?.Invoke(this, EventArgs.Empty);

            if (cuttingProgress >= cuttingRecipeSO.cuttingCounterMax)
            {
                KitchenObjectSO outputCuttingRecipeSO = GetOutputFromInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputCuttingRecipeSO, this);

                cuttingProgress = 0;
            }

            
        }
    }

    public bool HasRecipeWithInput(KitchenObjectSO kitchenObjectInput)
    {

        CuttingRecipeSO cuttingRecipeSO = GetCuttingCounterWithInput(kitchenObjectInput);

        return cuttingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputFromInput(KitchenObjectSO kitchenObjectInput)
    {

        CuttingRecipeSO cuttingRecipeSO = GetCuttingCounterWithInput(kitchenObjectInput);

        return cuttingRecipeSO.output;
    }


    private CuttingRecipeSO GetCuttingCounterWithInput(KitchenObjectSO inputKitchenObject)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOList)
        {
            if(cuttingRecipeSO.input == inputKitchenObject)
            {
                return cuttingRecipeSO;
            }
        }


        return null;
    }

}
