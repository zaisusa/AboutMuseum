using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationAboutMuseum : MonoBehaviour
{
    [SerializeField] public Sprite panel;

    public GameObject[] ContentPages;
    public GameObject[] VisualPanels;
    public Sprite[] PanelImages;
    public GameObject StartWindow;
    public GameObject ThisWindow;

    public GameObject ForwardBtn;

    private int NumberPage = 0;
    void Start()
    {

        panel = VisualPanels[1].GetComponent<Image>().sprite;
    }
    public void Back() 
    {
        if(NumberPage == 0)
        {
            CloseWindow();
        }
        else
        {
            for (int i = 0; i < ContentPages.Length; i++)
            {
                if (ContentPages[i].activeSelf)
                {
                    ContentPages[i].SetActive(false);
                }
            }
            NumberPage--;
            ContentPages[NumberPage].SetActive(true);
            ForwardBtn.SetActive(true);
            SelectVisualPanel(NumberPage, ContentPages.Length);
        }        
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
        NumberPage++;
        ContentPages[NumberPage].SetActive(true);
        SelectVisualPanel(NumberPage, ContentPages.Length);
        if (NumberPage == (ContentPages.Length - 1))
        {
            ForwardBtn.SetActive(false);
        }
        
    }
    private void CloseWindow()
    {
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
