using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiTouchedAnimation : MonoBehaviour {

    public GameObject fadeObj;
    public bool selected;
    public float slow = 0.7f;
    public bool sizeLerp, alphaLerp;
    public float newAlpha = 1.0f;
    public Vector2 newSize = new Vector2(160, 160);

    private Vector2 startSize;
    private bool isLerp = false;
    private float _timeStartedLerping;
    private Color fadeColor;
    private Color endColor;
    private Color startColor;
    private float timeToFade = 10.0f;
    private float actTime = 0;

    void Start () {
        
        startColor = fadeObj.GetComponent<Image>().color;
        endColor = fadeObj.GetComponent<Image>().color;

        startSize = fadeObj.GetComponent<RectTransform>().sizeDelta;
    }
	
	void FixedUpdate () {

        actTime += Time.deltaTime / timeToFade;

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / slow;

            fadeObj.SetActive(true);

            if (alphaLerp) {

                fadeObj.GetComponent<Image>().color = Color.Lerp(startColor, endColor, actTime);
            }

            if (sizeLerp) {

                fadeObj.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(fadeObj.GetComponent<RectTransform>().sizeDelta, newSize, actTime);
            }

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
        }
    }

    public void Activate()
    {

        switchColor();
        _timeStartedLerping = Time.time;
        selected = true;
        isLerp = true;
    }

    public void Deactivate() {

        switchColor();
        _timeStartedLerping = Time.time;
        selected = false;
        isLerp = true;
    }

    void switchColor () {

        if (selected)
        {

            endColor.a = 0;
        }
        else
        {

            endColor.a = newAlpha;
        }
    }
}