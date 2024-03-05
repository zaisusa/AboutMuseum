using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField] Button[] NabigationsBtn;
    [SerializeField] GameObject[] Windows;
    [SerializeField] Sprite[] VariableBtn;
    // Start is called before the first frame update

    public void SwipesImageButtons(Button _pressedBtn)
    {
        for(int i = 0; i < NabigationsBtn.Length; i++)
        {
            NabigationsBtn[i].image.sprite = VariableBtn[1];
            NabigationsBtn[i].interactable = true;
        }
        _pressedBtn.image.sprite = VariableBtn[0];
        _pressedBtn.interactable = false;
    }
    public void CrossWindows(GameObject _selectedWindow)
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i].SetActive(false);
        }
        _selectedWindow.SetActive(true);
    }

}
