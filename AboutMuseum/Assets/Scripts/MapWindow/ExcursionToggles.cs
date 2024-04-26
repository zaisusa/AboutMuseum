using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExcursionToggles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ExcursionOnMap;
    [SerializeField] GameObject BriefInfoPrefab;
    [SerializeField] Transform PlaceOfBrief;

    Exposition needExposition;
    GameObject BriefInfoWindow;

    TMP_Text textExp;
    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate { SwapMap1(); });

        needExposition = ExcursionOnMap.GetComponent<Exposition>();
        needExposition.ExcOnNavigation = GetComponent<Toggle>();

        Initialization();
    }
    void SwapMap1()
    {
        if (BriefInfoWindow)
        {
            needExposition.SwipeSprite();
            SwapColorText();
            CloseBriefInfo();
        }
        else
        {
            needExposition.SwipeSprite();
            SwapColorText();
            OpenBriefInfo();
        }
        //if (ExcursionOnMap.activeSelf)
        //{
        //    ExcursionOnMap.SetActive(false);
        //    CloseBriefInfo();
        //}
        //else
        //{
        //    ExcursionOnMap.SetActive(true);
        //    OpenBriefInfo();
        //}
    }
    void OpenBriefInfo()
    {
        BriefInfoWindow = Instantiate(BriefInfoPrefab);
        BriefInfoWindow.transform.SetParent(PlaceOfBrief);
        BriefInfoWindow.GetComponent<RectTransform>().offsetMax = new Vector2(-72f, -80f);
        BriefInfoWindow.GetComponent<RectTransform>().offsetMin = new Vector2(840f, 666f);


        BriefInfoWindow.GetComponent<BriefInfo>().FillingText(needExposition.expositionInfo.Name,
            needExposition.expositionInfo.BriefInfo, needExposition.expositionInfo.Image);
    }
    public void CloseBriefInfo()
    {
        Destroy(BriefInfoWindow);
    }

    void Initialization()
    {
        textExp = transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        textExp.text = needExposition.expositionInfo.Name;

    }
    void SwapColorText()
    {
        if(textExp.color == Color.black)
        {
            textExp.color = Color.white;
        }
        else
        {
            textExp.color = Color.black;
        }
    }
    // Update is called once per frame
    
}
