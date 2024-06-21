using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterWindowLogic : MonoBehaviour
{
    [SerializeField] GameObject Content;
    public GameObject[] Excursions;
    [SerializeField] GameObject FilterGroup;
    

    [SerializeField] GameObject ThisWindow;
    [SerializeField] GameObject StartWindow;

    public PosterLoad loadContent;
    void Start()
    {
        
        
    }
    public void OnStartWindow()
    {
        FilterGroup.GetComponent<FiltersLogic>().OnStart();
        StartCoroutine(GetContentSize());
        
    }
    public void CloseWindow()
    {
        ClearContent();
        FilterGroup.GetComponent<FiltersLogic>().ClearContentListOnExit();
        StartWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }
    void ClearContent()
    {
        int CountExc = Excursions.Length;
        for (int i = 0; i < CountExc; i++)
        {
            Destroy(Excursions[i].gameObject);
        }
    }

    IEnumerator GetContentSize()
    {
        yield return new WaitForSeconds(0.5f);
        Excursions = Content.GetComponent<PosterLoad>().content;
    }
}
