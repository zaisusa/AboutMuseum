using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMP_SIzeFilter : MonoBehaviour
{
    private float old_Height = 148f;
    public TMP_Text kk;
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;
    public TextMeshProUGUI TextMeshPro
    {
        get
        {
            if(m_TextMeshPro == null && transform.GetComponentInChildren<TextMeshProUGUI>())
            {
                m_TextMeshPro = transform.GetComponentInChildren<TextMeshProUGUI>();
                m_TMPRectTransform = m_TextMeshPro.rectTransform;
            }
            return m_TextMeshPro;
        }
    }
    private RectTransform m_RectTransform;
    public RectTransform rectTransform
    {
        get
        {
            if(m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform;
        }
    }
    private RectTransform m_TMPRectTransform;
    public RectTransform TMPRectTransform { get { return m_TMPRectTransform; } }

    private float m_PrefferedHeight;
    public float PrefferedHeight { get { return m_PrefferedHeight; } }
    public void SetHeight()
    {
        if (TextMeshPro == null || old_Height > TextMeshPro.preferredHeight)
        {
            return;
        }
        m_PrefferedHeight = TextMeshPro.preferredHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, m_PrefferedHeight+20f);
    }
    public void SetOldHeight()
    {
        if (TextMeshPro == null || old_Height > TextMeshPro.preferredHeight)
        {
            return;
        }
        m_PrefferedHeight = old_Height;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, m_PrefferedHeight);
    }
    //private void OnEnable()
    //{
    //    //SetHeight();
    //}
    //void Start()
    //{
    //    old_Height = TextMeshPro.renderedHeight;
    //    //SetHeight();
    //    print(kk.renderedHeight + " " + TextMeshPro.preferredHeight);
    //}

    //void Update()
    //{
    //    print(kk.renderedHeight + " " + TextMeshPro.preferredHeight);
    //    if (PrefferedHeight != TextMeshPro.preferredHeight)
    //    {
    //        SetHeight();
    //    }
    //}
}
