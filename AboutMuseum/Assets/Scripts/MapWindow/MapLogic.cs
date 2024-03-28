using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] ButtonStyles;
    [SerializeField] GameObject[] Floors;

    [SerializeField] Button backBtn;
    [SerializeField] GameObject ThisWindow;
    [SerializeField] GameObject StartWindow;

    
    private void Start()
    {
        //backBtn = transform.Find("MapFloors/BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(delegate { CloseFloors(null); GoOnWindow(); });
    }
    public void OpenFloor(Button floorBtn)
    {
        OpenAndCloseButton(floorBtn); 
    }
    void OpenAndCloseButton(Button floorBtn)
    {
        var floor = floorBtn.GetComponent<Floor>();
        bool _isOpen = floor.isOpen;
        if (_isOpen)
        {
            SwapStyles(floorBtn, 0, false);
        }
        else
        {
            CloseFloors(floorBtn);
            SwapStyles(floorBtn, 1, true);
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
    public void GoOnWindow()
    {
        StartWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }


}
