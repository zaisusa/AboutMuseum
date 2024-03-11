using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationOnWindows : MonoBehaviour
{
    public GameObject ThisWindow;
    public GameObject NeedWindow;
    
    public void GoOnWindow()
    {
        NeedWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }

}
