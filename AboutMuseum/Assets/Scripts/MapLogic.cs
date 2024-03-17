using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] ButtonStyles;
    [SerializeField] GameObject[] Floors;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenFloor(Button floorBtn)
    {
        SwapStyleButton(floorBtn); 

    }
    void SwapStyleButton(Button floorBtn)
    {
        bool _isOpen = floorBtn.GetComponent<Floor>().isOpen;
        if (_isOpen)
        {
            floorBtn.image.sprite = ButtonStyles[0];
            floorBtn.image.SetNativeSize();
            floorBtn.GetComponent<Floor>().isOpen = false;
        }
        else
        {
            CloseFloors(floorBtn);
            floorBtn.image.sprite = ButtonStyles[1];
            floorBtn.image.SetNativeSize();
            floorBtn.GetComponent<Floor>().isOpen = true;
            
        }
    }
    void CloseFloors(Button floorBtn)
    {
        foreach(var a in Floors)
        {
            if (a.GetComponent<Button>() != floorBtn)
            {
                Button _this = a.GetComponent<Button>();
                _this.image.sprite = ButtonStyles[0];
                _this.image.SetNativeSize();
                _this.GetComponent<Floor>().isOpen = false;
            }
        }
        
    }
}
