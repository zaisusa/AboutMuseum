using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{

    public bool isOpen = false;
    public GameObject FloorOnMap;

    [SerializeField] ToggleGroup excursionToggles;
    Toggle activeToggle;
    public void ClosedExc()
    {
        activeToggle = excursionToggles.GetFirstActiveToggle();
        if (activeToggle)
        {
            
            activeToggle.isOn = false;
            activeToggle.gameObject.GetComponent<ExcursionToggles>().CloseBriefInfo();
        } 
    }


}
