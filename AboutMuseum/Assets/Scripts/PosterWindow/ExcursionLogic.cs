using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcursionLogic : MonoBehaviour
{
    public int Month;
    [SerializeField] int SizeFull;


    RectTransform thisTransform;
    public bool isOpen = false;
    private void Start()
    {
        thisTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(delegate { OpenFullInfo(); });
    }
    public void OpenFullInfo()
    {
        if (!isOpen)
        {
            thisTransform.offsetMin = new Vector2(thisTransform.offsetMin.x, thisTransform.offsetMin.y - SizeFull);
            isOpen = true;
        }
        else
        {
            thisTransform.offsetMin = new Vector2(thisTransform.offsetMin.x, thisTransform.offsetMin.y + SizeFull);
            isOpen = false;
        }

        //print(thisTransform.offsetMin);
    }
}
