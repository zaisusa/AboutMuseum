using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewAnswer : MonoBehaviour
{
    RectTransform transformAnswer;
    void Start()
    {
        transformAnswer = GetComponent<RectTransform>();
        transformAnswer.anchoredPosition.Set(0f, 0f);
        
        transformAnswer.offsetMax = new Vector2(-612f, 12f);
        transformAnswer.offsetMin = new Vector2(612f, 973f);
        StartCoroutine(CloseAnswer());
    }
    IEnumerator CloseAnswer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


}
