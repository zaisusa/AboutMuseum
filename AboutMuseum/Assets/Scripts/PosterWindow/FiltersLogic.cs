using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FiltersLogic : MonoBehaviour
{
    Dictionary<int, string> MonthNames = new Dictionary<int, string>()
    {
        {1,"ﬂÕ¬¿–‹" },
        {2,"‘≈¬–¿À‹" },
        {3,"Ã¿–“" },
        {4,"¿œ–≈À‹" },
        {5,"Ã¿…" },
        {6,"»ﬁÕ‹" },
        {7,"»ﬁÀ‹" },
        {8,"¿¬√”—“" },
        {9,"—≈Õ“ﬂ¡–‹" },
        {10,"Œ “ﬂ¡–‹" },
        {11,"ÕŒﬂ¡–‹" },
        {12,"ƒ≈ ¿¡–‹" }
    };
    [SerializeField] GameObject Content;
    [SerializeField] GameObject[] Excursions;

    GameObject[] filters = new GameObject[3];

    PosterLoad loader;
    DateTime date = DateTime.Now;

    [SerializeField] GameObject imageZero;
    private void Start()
    {
        
    }
    public void OnStart()
    {
        loader = Content.GetComponent<PosterLoad>();
        int indexMonth = date.Month;
        for (int i = 0; i < 3; i++)
        {
            filters[i] = transform.GetChild(i).gameObject;
            filters[i].GetComponent<ToggleFilter>().SelectMonth(indexMonth + i);
            SwapNamesFilter(indexMonth + i, filters[i]);
        }

        filters[0].GetComponent<Toggle>().Select();
        //Click(indexMonth);
    }
    public void Click(int _indexMonth)
    {
        ClearContentList();
        loader.LoadOnStart(_indexMonth);
        
    }
    public void UploadContentList()
    {
        Excursions = loader.content;
        if (Excursions.Length ==0) ZeroExcursions(true);
        else ZeroExcursions(false);
    }
    public void ClearContentList()
    {
        for (int i =0; i < Excursions.Length; i++)
        {
            Destroy(Excursions[i]);
        }
    }
    void SwapNamesFilter(int _indexMonth, GameObject filter)
    {

        string textName = MonthNames[_indexMonth];
        filter.transform.GetChild(1).GetComponent<TMP_Text>().text = textName;
    }
    public void ZeroExcursions(bool isTrue)
    {
        imageZero.SetActive(isTrue);
    }
    public void ClearContentListOnExit()
    {
        filters[0].GetComponent<Toggle>().isOn = true;
        for (int i = 0; i < Excursions.Length; i++)
        {
            Destroy(Excursions[i]);
        }
    }
}
