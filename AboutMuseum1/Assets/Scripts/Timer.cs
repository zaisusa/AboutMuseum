using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    DateTime date;

    TMP_Text timer;
    void Start()
    {
        timer = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        date = DateTime.Now;
        if (date.Minute.ToString().Length == 1)
        {
            timer.text = $"{date.Day} {MonthNames[date.Month]} - {date.Hour}:0{date.Minute}";
        }
        else
        {
            timer.text = $"{date.Day} {MonthNames[date.Month]} - {date.Hour}:{date.Minute}";
        }  
    }

    Dictionary<int, string> MonthNames = new Dictionary<int, string>()
    {
        {1,"������" },
        {2,"�������" },
        {3,"�����" },
        {4,"������" },
        {5,"���" },
        {6,"����" },
        {7,"����" },
        {8,"�������" },
        {9,"��������" },
        {10,"�������" },
        {11,"������" },
        {12,"�������" }
    };
}
