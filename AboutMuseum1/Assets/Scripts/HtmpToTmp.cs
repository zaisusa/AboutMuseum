using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HtmpToTmp : MonoBehaviour
{
    public static string ConvertHTMLToTMP(string htmlText)
    {
        // Замена перевода строки <br> и <br/>
        htmlText = Regex.Replace(htmlText, "<br>", "\n");
        htmlText = Regex.Replace(htmlText, "<br/>", "\n");

        // Замена <strong> аналогично <b>
        htmlText = Regex.Replace(htmlText, "<strong>", "<b>");
        htmlText = Regex.Replace(htmlText, "</strong>", "</b>");

        // Замена <em> аналогично <i>
        htmlText = Regex.Replace(htmlText, "<em>", "<i>");
        htmlText = Regex.Replace(htmlText, "</em>", "</i>");

        // Условная замена для <p>
        htmlText = Regex.Replace(htmlText, "<p></p>", "");
        htmlText = Regex.Replace(htmlText, @"^\s*<p>\s*", "", RegexOptions.Multiline);
        htmlText = Regex.Replace(htmlText, @"\s*<p>\s*", "\n");

        // Условная замена для </p>
        htmlText = Regex.Replace(htmlText, @"\s*</p>\s*$", "", RegexOptions.Multiline);
        htmlText = Regex.Replace(htmlText, @"\s*</p>\s*", "\n");

        // Замена &nbsp; на пространство
        htmlText = Regex.Replace(htmlText, "&nbsp;", " ");

        return htmlText;
    }
}
