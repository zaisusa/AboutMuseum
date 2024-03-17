using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcursionLogic : MonoBehaviour
{
    public int Month;



    RectTransform thisTransform;
    private bool isOpen = false;
    private void Start()
    {
        thisTransform = GetComponent<RectTransform>();
    }
    public void OpenFullInfo(int openSize)
    {
        if (!isOpen)
        {
            thisTransform.offsetMin = new Vector2(thisTransform.offsetMin.x, thisTransform.offsetMin.y - openSize);
            isOpen = true;
        }
        else
        {
            thisTransform.offsetMin = new Vector2(thisTransform.offsetMin.x, thisTransform.offsetMin.y + openSize);
            isOpen = false;
        }

        //print(thisTransform.offsetMin);
    }
}
