using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate { SwapMap1(); });
        needExposition = ExcursionOnMap.GetComponent<Exposition>();
    }
    void SwapMap1()
    {

        if (ExcursionOnMap.activeSelf)
        {
            ExcursionOnMap.SetActive(false);
            CloseBriefInfo();
        }
        else
        {
            ExcursionOnMap.SetActive(true);
            OpenBriefInfo();
        }
    }
    void OpenBriefInfo()
    {
        BriefInfoWindow = Instantiate(BriefInfoPrefab);
        BriefInfoWindow.transform.SetParent(PlaceOfBrief);
        BriefInfoWindow.GetComponent<RectTransform>().offsetMax = new Vector2(-72f, -137f);
        BriefInfoWindow.GetComponent<RectTransform>().offsetMin = new Vector2(840f, 620f);


        BriefInfoWindow.GetComponent<BriefInfo>().FillingText(needExposition.expositionInfo.Name,
            needExposition.expositionInfo.BriefInfo, needExposition.expositionInfo.Image);
    }
    public void CloseBriefInfo()
    {
        Destroy(BriefInfoWindow);
    }


    // Update is called once per frame
    
}
