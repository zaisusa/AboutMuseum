using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BriefInfo : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Description;
    public Image Image;

    public void FillingText(string _name, string _description, Sprite _image)
    {
        Name.text = _name;
        Description.text = _description;
        Image.sprite = _image;
    }

}
