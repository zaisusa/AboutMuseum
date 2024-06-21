using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valuation : MonoBehaviour
{
    public int Value =5;
    GameObject[] stars = new GameObject[5];

    public Sprite[] ImageStars;
    void Start()
    {
        
        for (int i=0; i<5; i++)
        {
            stars[i] = transform.GetChild(i).gameObject;
        }
        SwapColor(1, 0);
    }

    public void SetValue(int _value)
    {
        Value = _value;
        SwapColor(0,1);
        
    }
    void SwapColor(int goldstars, int whitestars)
    {
        if(Value == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                stars[i].GetComponent<RawImage>().texture = ImageStars[goldstars].texture;
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                stars[i].GetComponent<RawImage>().texture = ImageStars[whitestars].texture;
            }
            for (int i = 0; i < Value; i++)
            {
                stars[i].GetComponent<RawImage>().texture = ImageStars[goldstars].texture;
            }
        }
        
        
    }
}
