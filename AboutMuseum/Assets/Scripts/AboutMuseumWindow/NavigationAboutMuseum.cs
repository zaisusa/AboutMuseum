using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationAboutMuseum : MonoBehaviour
{

    [SerializeField] GameObject[] ContentPages;
    [SerializeField] GameObject[] VisualPanels;
    [SerializeField] Sprite[] PanelImages;
    [SerializeField] GameObject StartWindow;
    [SerializeField] GameObject ThisWindow;

    [SerializeField] GameObject BackBtn;
    [SerializeField] GameObject ForwardBtn;

    private int NumberPage = 0;


    public void Back() 
    {
        for (int i = 0; i < ContentPages.Length; i++)
        {
            if (ContentPages[i].activeSelf)
            {
                ContentPages[i].SetActive(false);
            }
        }
        if (NumberPage == 1)
        {
            BackBtn.SetActive(false);
        }
        NumberPage--;
        ContentPages[NumberPage].SetActive(true);
        ForwardBtn.SetActive(true);
        SelectVisualPanel(NumberPage, ContentPages.Length);
               
    }
    public void Forward()
    {

        for (int i = 0; i < ContentPages.Length; i++)
        {
            if (ContentPages[i].activeSelf)
            {
                ContentPages[i].SetActive(false);
            }
        }
        if (BackBtn) BackBtn.SetActive(true);
        NumberPage++;
        ContentPages[NumberPage].SetActive(true);
        SelectVisualPanel(NumberPage, ContentPages.Length);
        if (NumberPage == (ContentPages.Length - 1))
        {
            ForwardBtn.SetActive(false);
        }
        
    }
    public void ClearProgress()
    {
        while(NumberPage != 0)
        {
            Back();
        }
        ThisWindow.SetActive(false);
        StartWindow.SetActive(true);
    }
    private void SelectVisualPanel(int _nmbOfPanel, int _lenght)
    {
        for (int i = 0; i < _lenght; i++)
        {
            VisualPanels[i].GetComponent<Image>().sprite = PanelImages[1];
        }
        VisualPanels[_nmbOfPanel].GetComponent<Image>().sprite = PanelImages[0];
    }

}
