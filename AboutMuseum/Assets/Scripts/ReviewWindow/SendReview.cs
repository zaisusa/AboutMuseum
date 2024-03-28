using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendReview : MonoBehaviour
{
    
    public GameObject ThisWindow;
    public GameObject StartWindow;
    

    public GameObject Answer;
    public GameObject Canvas;


    public TMP_InputField first;
    public TMP_InputField second;

    public Valuation markReview;
    public void SendingReview()
    {
        GoOnWindow();
        ReviewAnswer(Answer, Canvas);
    }
    void ReviewAnswer(GameObject _prefabAnswer, GameObject _window)
    {
        GameObject answer = Instantiate(_prefabAnswer);
        answer.transform.SetParent(_window.transform);
    }
    public void GoOnWindow()
    {
        StartWindow.SetActive(true);
        ClearReview();
        ThisWindow.SetActive(false); 
    }
    void ClearReview()
    {
        first.text = "";
        second.text = "";
        markReview.SetValue(5);
    }

}
