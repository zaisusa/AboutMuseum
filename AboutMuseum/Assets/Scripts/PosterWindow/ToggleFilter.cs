using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleFilter : MonoBehaviour, ISelectHandler
{
    GameObject parent;
    public FiltersLogic filter;
    int Month;
    TMP_Text textName;
    Toggle item;
    private void Awake()
    {
        parent = transform.parent.gameObject;
        filter = parent.GetComponent<FiltersLogic>();
        textName = transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        item = GetComponent<Toggle>();

    }
    private void Start()
    {
        item.onValueChanged.AddListener(delegate { BlackColor(); });
    }   
    public void SelectMonth(int indexMonth)
    {
        Month = indexMonth;
    }

    public void OnSelect(BaseEventData eventData)
    {
        WhiteColor();
        filter.Click(Month);
    }


    void BlackColor()
    {
        if(!item.isOn) textName.color = Color.black;

    }
    void WhiteColor()
    {
        textName.color = Color.white;
    }

    
}
