using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleFilter : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    GameObject parent;
    public FiltersLogic filter;
    int Month;
    TMP_Text textName;
    private void Awake()
    {
        parent = transform.parent.gameObject;
        filter = parent.GetComponent<FiltersLogic>();
        textName = transform.Find("Text (TMP)").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        
    }
    public void SelectMonth(int indexMonth)
    {
        Month = indexMonth;
    }

    public void OnSelect(BaseEventData eventData)
    {
        print("Я выбран");
        WhiteColor();
        filter.Click(Month);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        
        BlackColor();
    }
    void SwapTextColor()
    {
        
        if(textName.color == Color.black)
        {
            textName.color = Color.white;
        }
        else
        {
            textName.color = Color.black;
        }
        
    }
    void BlackColor()
    {
        textName.color = Color.black;

    }
    void WhiteColor()
    {
        textName.color = Color.white;
    }

    
}
