using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Excursion")]
public class Excursion : ScriptableObject
{
    public string Name;
    public string TopicExc { get; set; }
    DateTime Time { get; set; }
    Ticket[] Tickets;
    string Info { get; set; }
    Image Post;
    
    public Excursion(string _name, string _topicExc)
    {
        Name = _name;
        TopicExc = _topicExc;
    }
}
public class Ticket
{
    int Cost { get; set; }
    enum AgeType
    {
        Adult, Child, Benefit
    }
}
