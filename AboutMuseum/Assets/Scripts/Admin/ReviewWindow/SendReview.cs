using Assets.Scripts.Admin;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SendReview : MonoBehaviour
{

    [Header ("Navigation")]
    public GameObject ThisWindow;
    public GameObject StartWindow;

    [Header("Answer")]
    public GameObject Answer;
    public GameObject Canvas;

    [Header("Fields")]
    public TMP_InputField first;
    public TMP_InputField second;

    public Valuation markReview;
    public void SendingReview()
    {
        StartCoroutine(SendReviewOnAPI("http://192.168.0.240:8888/api/feedback",
            first.text, second.text, markReview.Value));
        
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
    IEnumerator SendReviewOnAPI(string url, string _name, string _text, int _rating)
    {
        if(_rating == 0)
        {
            _rating = 5;
        }

        WWWForm formData = new WWWForm();
        AnswerStruct answer = new AnswerStruct()
        {
            name = _name,
            text = _text,
            rating = _rating
        };
        string json = JsonUtility.ToJson(answer);
        UnityWebRequest request = UnityWebRequest.Post(url, formData);
        byte[] postBytes = Encoding.UTF8.GetBytes(json);
        UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);
        request.uploadHandler = uploadHandler;
        request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.Log("Error with Sendind Answer");
            request.Dispose();
        }

        GoOnWindow();
        ReviewAnswer(Answer, Canvas);
        request.Dispose();
    }

}
