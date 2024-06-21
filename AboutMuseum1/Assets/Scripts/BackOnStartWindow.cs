using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOnStartWindow : MonoBehaviour
{
    [SerializeField]int timeInaction = 0;
    [SerializeField] Button[] BackButtons;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKey)
        {
            timeInaction = 0;
            StopAllCoroutines();
            StartCoroutine(TimeLastClick());
        }
    }

    IEnumerator TimeLastClick()
    {
        while(timeInaction < 60)
        {
            timeInaction++;
            yield return new WaitForSeconds(1);
        }
        CloseWindow();
    }
    void CloseWindow()
    {
        foreach(var btn in BackButtons)
        {
            if (btn.IsActive())
            {
                print(btn);
                btn.onClick.Invoke();
            }
        }
    }
}
