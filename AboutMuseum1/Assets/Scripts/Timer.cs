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
        {1,"ﬂÕ¬¿–ﬂ" },
        {2,"‘≈¬–¿Àﬂ" },
        {3,"Ã¿–“¿" },
        {4,"¿œ–≈Àﬂ" },
        {5,"Ã¿ﬂ" },
        {6,"»ﬁÕﬂ" },
        {7,"»ﬁÀﬂ" },
        {8,"¿¬√”—“¿" },
        {9,"—≈Õ“ﬂ¡–ﬂ" },
        {10,"Œ “ﬂ¡–ﬂ" },
        {11,"ÕŒﬂ¡–ﬂ" },
        {12,"ƒ≈ ¿¡–ﬂ" }
    };
}
