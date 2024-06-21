using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ExcursionLogic : MonoBehaviour
{
    Dictionary<int, string> MonthNames = new Dictionary<int, string>()
    {
        {1,"������" },
        {2,"�������" },
        {3,"�����" },
        {4,"������" },
        {5,"���" },
        {6,"����" },
        {7,"����" },
        {8,"�������" },
        {9,"��������" },
        {10,"�������" },
        {11,"������" },
        {12,"�������" }
    };
    public int Month = 1;
    [SerializeField] int SizeFull;


    RectTransform thisTransform;
    public bool isOpen = false;


    [Header("Fields of Excursion")]
    public GameObject Image;
    public GameObject Title;
    public GameObject DateDay;
    public GameObject _DateTime;
    public GameObject Cost;
    public GameObject Description;

    private TMP_SIzeFilter FilterSize;
    private void Start()
    {
        thisTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(delegate { OpenFullInfo(); });
        FilterSize = GetComponent<TMP_SIzeFilter>();
    }
    public void OpenFullInfo()
    {
        if (!isOpen)
        {
            FilterSize.SetHeight();
            isOpen = true;
        }
        else
        {
            FilterSize.SetOldHeight();
            isOpen = false;
        }

        //print(thisTransform.offsetMin);
    }
    public void FillingFields(string urlImage, string title, string dateDay, string dateTime, int cost, string description)
    {
        StartCoroutine(LoadPicture(urlImage));
        Title.GetComponent<TMP_Text>().text = title;
        DateDay.GetComponent<TMP_Text>().text = TranslateDateDay(dateDay,Month);
        _DateTime.GetComponent<TMP_Text>().text = dateTime;
        Cost.GetComponent<TMP_Text>().text = $"�� {cost}�";
        Description.GetComponent<TMP_Text>().text = description;
    }
    string TranslateDateDay(string dateDay, int month)
    {
        var day = dateDay.Substring(dateDay.Length - 2, 2);
        if (day.Substring(0, 1) == "-")
        {
            day = dateDay.Substring(dateDay.Length - 1, 1);
        }
        return $"{day} {MonthNames[month]}";
    }
    IEnumerator LoadPicture(string _urlImage)
    {
        if (_urlImage != "")
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(_urlImage);
            yield return request.SendWebRequest();
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Image.GetComponent<Image>().sprite = image;
        }
        
        

    }
}
