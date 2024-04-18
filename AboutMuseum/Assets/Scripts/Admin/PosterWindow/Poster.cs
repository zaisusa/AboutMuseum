using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Admin
{
    [System.Serializable]
    public struct Poster
    {
        public int id;
        public string title;
        public string description;
        public string image;
        public string premiereDate;
        public string premiereTime;
        public int price;
    }
}