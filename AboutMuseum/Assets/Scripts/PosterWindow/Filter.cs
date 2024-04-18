using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    ToggleGroup Filters;
    [SerializeField] GameObject Content;
    GameObject[] Excursions;

    [SerializeField] GameObject ZeroExcImage;
    void Start()
    {
        Filters = GetComponent<ToggleGroup>();
        Excursions = Content.GetComponent<PosterLoad>().content;
        //Excursions = WindowLogic.Excursions;
    }
    private void FixedUpdate()
    {
        Excursions = Content.GetComponent<PosterLoad>().content;
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
        int Count = 0;
        if (!Filters.GetFirstActiveToggle())
        {
            for (int i = 0; i < Excursions.Length; i++)
            {
                Excursions[i].SetActive(true);
                ZeroExcImage.SetActive(false);
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
                    Count++;
                }
            }
            if (Count == 0)
            {
                ZeroExcImage.SetActive(true);
            }
            else ZeroExcImage.SetActive(false);
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
                ZeroExcImage.SetActive(false);
            }
        }
    }
}
