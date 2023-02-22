using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [Header("Selected Counter Atts")]
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;

    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }

    private void Instance_OnSelectedCounterChanged(object sender, System.EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Show()
    {
        visualGameObject.SetActive(true);
    }

    void Hide()
    {
        visualGameObject.SetActive(false);
    }


}
