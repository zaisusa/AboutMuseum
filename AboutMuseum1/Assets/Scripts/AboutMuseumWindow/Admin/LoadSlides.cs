using Assets.Scripts.Admin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LoadSlides : MonoBehaviour
{
    HtmpToTmp conventer;
    Dictionary<string, int> SlidesID = new Dictionary<string, int>()
    {
        {"ONE", 0},
        {"TWO", 1},
        {"THREE", 2},
        {"FOUR", 3},
        {"FIVE", 4},
    };
    string URL;
    [SerializeField]TMP_Text[] slidesText = new TMP_Text[5];
    public void LoadOnStart()
    {
        URL = $"http://95.188.79.124:8888/api/info";
        StartCoroutine(UploadSlides(URL));
    }
    void SetSlideContext(Slide _slide)
    {
        int idSlide = SlidesID[_slide.slide];
        string newText = HtmpToTmp.ConvertHTMLToTMP(_slide.text);
        slidesText[idSlide].text = newText;
    }
    void InitializationSlides(Slide[] slides)
    {
        foreach(var slide in slides)
        {
            SetSlideContext(slide);
        }
    }
    IEnumerator UploadSlides(string _url)
    {

        UnityWebRequest request = UnityWebRequest.Get(_url);
        yield return request.SendWebRequest();
        AllSlides allSlides = JsonUtility.FromJson<AllSlides>(request.downloadHandler.text);
        InitializationSlides(allSlides.items);
    }
}
