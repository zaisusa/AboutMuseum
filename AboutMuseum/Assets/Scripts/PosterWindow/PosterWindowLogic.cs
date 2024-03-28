using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterWindowLogic : MonoBehaviour
{
    public GameObject Content;
    public GameObject[] Excursions;
    [SerializeField] GameObject FilterGroup;
    int CountExc;

    [SerializeField] GameObject ThisWindow;
    [SerializeField] GameObject StartWindow;


    void Start()
    {
        CountExc = Content.transform.childCount;
        Excursions = new GameObject[CountExc];
        for (int i = 0; i < CountExc; i++)
        {
            Excursions[i] = Content.transform.GetChild(i).gameObject;
        }
    }
    public void CloseWindow()
    {
        for (int i = 0; i < CountExc; i++)
        {
            var excLogic = Excursions[i].GetComponent<ExcursionLogic>();
            if (excLogic.isOpen)
            {
                excLogic.OpenFullInfo();
            }
        }
        FilterGroup.GetComponent<Filter>().UnEnabledAll();
        StartWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }


}
