using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapToggles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Texture[] sprites;
    [SerializeField] RawImage map1;
    public void SwapMap1()
    {
        if (map1.texture == sprites[0])
        {
            map1.texture = sprites[1];

        }
        else
        {
            map1.texture = sprites[0];

        }
    }

    // Update is called once per frame
    
}
