using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HtmpToTmp : MonoBehaviour
{
    public static string ConvertHTMLToTMP(string htmlText)
    {
        // ������ �������� ������ <br> � <br/>
        htmlText = Regex.Replace(htmlText, "<br>", "\n");
        htmlText = Regex.Replace(htmlText, "<br/>", "\n");

        // ������ <strong> ���������� <b>
        htmlText = Regex.Replace(htmlText, "<strong>", "<b>");
        htmlText = Regex.Replace(htmlText, "</strong>", "</b>");

        // ������ <em> ���������� <i>
        htmlText = Regex.Replace(htmlText, "<em>", "<i>");
        htmlText = Regex.Replace(htmlText, "</em>", "</i>");

        // �������� ������ ��� <p>
        htmlText = Regex.Replace(htmlText, "<p></p>", "");
        htmlText = Regex.Replace(htmlText, @"^\s*<p>\s*", "", RegexOptions.Multiline);
        htmlText = Regex.Replace(htmlText, @"\s*<p>\s*", "\n");

        // �������� ������ ��� </p>
        htmlText = Regex.Replace(htmlText, @"\s*</p>\s*$", "", RegexOptions.Multiline);
        htmlText = Regex.Replace(htmlText, @"\s*</p>\s*", "\n");

        // ������ &nbsp; �� ������������
        htmlText = Regex.Replace(htmlText, "&nbsp;", " ");

        return htmlText;
    }
}
