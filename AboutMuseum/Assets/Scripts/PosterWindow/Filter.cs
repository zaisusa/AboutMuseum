using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    [SerializeField] PosterWindowLogic WindowLogic;
    ToggleGroup Filters;
    GameObject[] Excursions;
    void Start()
    {
        Filters = GetComponent<ToggleGroup>();
        Excursions = WindowLogic.Excursions;
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
    public void UnEnabledAll()
    {
        var activeToggle = Filters.GetFirstActiveToggle();
        if (activeToggle)
        {
            activeToggle.isOn = false;
            for (int i = 0; i < Excursions.Length; i++)
            {
                Excursions[i].SetActive(true);
            }
        }
    }
}
