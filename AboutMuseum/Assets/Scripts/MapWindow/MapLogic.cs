using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] ButtonStyles;
    [SerializeField] GameObject[] Floors;
    static GameObject[] _floors;

    [SerializeField] Button backBtn;
    [SerializeField] GameObject ThisWindow;
    [SerializeField] GameObject StartWindow;

    int indexStyle = 1;
    [SerializeField] Button firstFloor;


    private void Start()
    {
        _floors = new GameObject[4]
        {
            Floors[0],Floors[1],Floors[2],Floors[3]
        };
        //backBtn = transform.Find("MapFloors/BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(delegate { CloseFloors(null); GoOnWindow(); });
    }
    public void SetIndexStyle(int index)
    {
        indexStyle = index;
    }
    public void OpenFloor(Button floorBtn)
    {
        OpenAndCloseButton(floorBtn, indexStyle);
    }
    void OpenAndCloseButton(Button floorBtn, int indexStyle)
    {
        var floor = floorBtn.GetComponent<Floor>();
        bool _isOpen = floor.isOpen;
        if (_isOpen)
        {
            return;
            //SwapStyles(floorBtn, 0, false);
            //SetIndexStyle(1);
            //OpenFloor(firstFloor);
        }
        else
        {
            CloseFloors(floorBtn);
            SwapStyles(floorBtn, indexStyle, true);
        }
    }

    void SwapStyles(Button floor, int indexStyle, bool isOpen)
    {
        var floorComp = floor.GetComponent<Floor>();
        floor.image.sprite = ButtonStyles[indexStyle];
        floor.image.SetNativeSize();
        floorComp.ClosedExc();
        floorComp.isOpen = isOpen;
        floorComp.FloorOnMap.SetActive(isOpen);
    }

#nullable enable
    public void CloseFloors(Button? floorBtn)
    {
        foreach (var anotherFloor in Floors)
        {
            if (anotherFloor.GetComponent<Button>() != floorBtn)
            {
                Button _this = anotherFloor.GetComponent<Button>();
                SwapStyles(_this, 0, false);
            }
        }


    }
#nullable disable
    #region Blocking Activities
    void SerializeExpositions()
    {
        foreach (var floor in Floors)
        {
            Floor floorComp = floor.GetComponent<Floor>();
            var mapExp = floorComp.FloorOnMap;
        }
    }
    static public GameObject[] GetAllChildrens(GameObject gameObject)
    {
        int count = gameObject.transform.childCount;
        GameObject[] childrens = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            childrens[i] = gameObject.transform.GetChild(i).gameObject;
        }
        return childrens;
    }
    public static void BlockActivity(bool _isOn)
    {
        foreach (var floor in _floors)
        {
            Floor floorComp = floor.GetComponent<Floor>();
            BlockFloor(floorComp, _isOn);
        }
    }
    private static void BlockFloor(Floor floor, bool _isOn)
    {
        foreach(var exp in floor.ContentOnMap)
        {
            exp.GetComponent<Button>().interactable = _isOn;
        }
        foreach (var exp in floor.ContentOnNav)
        {
            exp.GetComponent<Toggle>().interactable = _isOn;
        }
    }
    #endregion
    public void GoOnWindow()
    {
        StartWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }


}
