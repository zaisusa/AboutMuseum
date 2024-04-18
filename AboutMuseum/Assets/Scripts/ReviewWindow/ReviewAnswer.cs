using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReviewAnswer : MonoBehaviour
{
    RectTransform transformAnswer;
    public TMP_Text answer;
    void Start()
    {
        transformAnswer = GetComponent<RectTransform>();
        transformAnswer.anchoredPosition.Set(0f, 0f);
        
        transformAnswer.offsetMax = new Vector2(-707f, -27f);
        transformAnswer.offsetMin = new Vector2(707f, 997f);
        
        StartCoroutine(CloseAnswer());
    }

    IEnumerator CloseAnswer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }



}
