using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTest : MonoBehaviour {

    void Awake()
    {
        Image myImage = GetComponent<Image>();
        myImage.alphaHitTestMinimumThreshold = 0.4f;
    }
}
