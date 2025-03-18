using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSelectedVisual : MonoBehaviour
{
    private BaseCounter baseCounter;
    [SerializeField] private List<GameObject> counterSelectedGameObjectList;


    private void Awake()
    {
        
        baseCounter = GetComponentInParent<BaseCounter>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player.instace.OnSelectedCounterChanged += Instace_OnSelectedCounterChanged;

        Hide();
    }

    private void Instace_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.baseCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

   

    private void Show()
    {
        foreach (GameObject counterObject in counterSelectedGameObjectList)
        {
            counterObject.SetActive(true);
        }
    }

    private void Hide()
    {
       foreach (GameObject counterObject in counterSelectedGameObjectList)
       {
            counterObject.SetActive(false);
       }
    }
}
