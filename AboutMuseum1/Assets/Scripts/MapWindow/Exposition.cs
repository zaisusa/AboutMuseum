using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exposition : MonoBehaviour
{
    public int Number;
    public ExpositionScriptableObject expositionInfo;

    [HideInInspector] public Toggle ExcOnNavigation;

    [SerializeField] Sprite Selected;
    [SerializeField] Sprite UnSelected;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Changed(); });
    }
    public void Changed()
    {
        if (!ExcOnNavigation.isOn)
        {
            ExcOnNavigation.isOn = true;
        }
        else
        {
            ExcOnNavigation.isOn = false;
        }
        
    }
    public void SwipeSprite()
    {
        var thisIm = GetComponent<Image>();
        if (thisIm.sprite == Selected) thisIm.sprite = UnSelected;
        else thisIm.sprite = Selected;
    }
}
