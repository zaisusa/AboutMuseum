using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterWindowLogic : MonoBehaviour
{
    [SerializeField] GameObject Content;
    public GameObject[] Excursions;
    [SerializeField] GameObject FilterGroup;
    int CountExc;

    [SerializeField] GameObject ThisWindow;
    [SerializeField] GameObject StartWindow;


    void Start()
    {
        StartCoroutine(GetContentSize());
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

    IEnumerator GetContentSize()
    {
        yield return new WaitForSeconds(1f);
        Excursions = Content.GetComponent<PosterLoad>().content;
    }
}
