using Assets.Scripts.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PosterLoad : MonoBehaviour
{
    Dictionary<int, string> MonthNamesForRequests = new Dictionary<int, string>()
    {
        {1,"JANUARY" },
        {2,"FEBRUARY" },
        {3,"MARCH" },
        {4,"APRIL" },
        {5,"MAY" },
        {6,"JUNE" },
        {7,"JULY" },
        {8,"AUGUST" },
        {9,"SEPTEMBER" },
        {10,"OCTOBER" },
        {11,"NOVEMBER" },
        {12,"DECEMBER" }
    };
    string URL;


    public GameObject[] content;
    private int SizeContent;
    public GameObject ExcursionExample;

    [SerializeField] FiltersLogic filters;
    public void LoadOnStart(int Month)
    {
        int month = Month;
        URL = $"http://192.168.0.240:8888/api/poster?month={MonthNamesForRequests[month]}";
        StartCoroutine(LoadPoster(URL, month));
    }
    
    void FillingContent(Poster[] posters, int month)
    {
        foreach(var post in posters)
        {
            CreateNewExcurion(post, month);
        }
    }
    void CreateNewExcurion(Poster _excursionInfo, int month)
    {
        var exc = Instantiate(ExcursionExample);
        exc.transform.SetParent(transform);
        exc.GetComponent<ExcursionLogic>().Month = month;
        exc.GetComponent<ExcursionLogic>().FillingFields(_excursionInfo.image, _excursionInfo.title, _excursionInfo.premiereDate,
            _excursionInfo.premiereTime, _excursionInfo.price, _excursionInfo.description);
    }
    void InitializationExcursion()
    {
        SizeContent = transform.childCount;
        content = new GameObject[SizeContent];
        for(int i = 0; i < SizeContent; i++)
        {
            content[i] = transform.GetChild(i).gameObject;
        }
        filters.UploadContentList();
    }
    IEnumerator LoadPoster(string _url, int month)
    {
        
        UnityWebRequest request = UnityWebRequest.Get(_url);
        yield return request.SendWebRequest();
        AllPosters allPosters = JsonUtility.FromJson<AllPosters>(request.downloadHandler.text);
        FillingContent(allPosters.items, month);
        InitializationExcursion();
    }
    
    
}
