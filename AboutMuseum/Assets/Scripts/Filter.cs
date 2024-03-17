using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    ToggleGroup Filters;
    public GameObject Content;
    int CountExc;
    [SerializeField]GameObject[] Excursions;
    void Start()
    {
        Filters = GetComponent<ToggleGroup>();
        CountExc = Content.transform.childCount;
        Excursions = new GameObject[CountExc];
        for (int i =0; i < CountExc; i++)
        {
            Excursions[i] = Content.transform.GetChild(i).gameObject;
        }
    }

    //void UnenableToggles()
    //{
    //    for(int i = 0; i< MonthFilters.Length; i++)
    //    {
    //        MonthFilters[i].GetComponent<Toggle>().isOn = false;
    //    }
    //}
    public void SetFilterMonth(int indexMonth)
    {
        if (!Filters.GetFirstActiveToggle())
        {
            for (int i = 0; i < Excursions.Length; i++)
            {
                Excursions[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Excursions.Length; i++)
            {
                if (Excursions[i].GetComponent<ExcursionLogic>().Month != indexMonth)
                {
                    Excursions[i].SetActive(false);
                }
                else
                {
                    Excursions[i].SetActive(true);
                }
            }
        }
        
    }
}
