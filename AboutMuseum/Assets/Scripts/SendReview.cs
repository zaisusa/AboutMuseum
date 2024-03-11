using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReview : MonoBehaviour
{
    
    public GameObject ThisWindow;
    public GameObject StartWindow;
    

    public GameObject Answer;
    public GameObject Canvas;
    
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
    void GoOnWindow()
    {
        StartWindow.SetActive(true);
        ThisWindow.SetActive(false);
    }
    
}
