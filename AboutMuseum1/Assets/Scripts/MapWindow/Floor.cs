using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{

    public bool isOpen = false;
    public GameObject FloorOnMap;

    public ToggleGroup excursionToggles;
    Toggle activeToggle;

    //��� ���������� ����������� �� ����
    [HideInInspector] public GameObject[] ContentOnMap; //���������� �� �����
    [HideInInspector] public GameObject[] ContentOnNav; //���������� � ��������� (������ ����)
    public void ClosedExc()
    {
        activeToggle = excursionToggles.GetFirstActiveToggle();
        if (activeToggle)
        {
            
            activeToggle.isOn = false;
            activeToggle.gameObject.GetComponent<ExcursionToggles>().CloseBriefInfo();
        } 
    }
    private void Start()
    {
        ContentOnMap = MapLogic.GetAllChildrens(FloorOnMap);
        ContentOnNav = MapLogic.GetAllChildrens(excursionToggles.gameObject);
    }


}
