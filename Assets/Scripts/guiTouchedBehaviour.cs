using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiTouchedBehaviour : MonoBehaviour
{

    public bool selected{

        set;
        get;
    }
    public enum TransitionOption
    {
        none, //no lerp
        alpha,
        color,
        fill,
        size,
        sprite//no lerp
    };

    public string ButtonDescription = "My Job is...";
    public TransitionOption transitionOption;
    public Sprite endSprite;
    public GameObject fadeObj;
    public float slow = 0.7f;
    public Vector2 newSize = new Vector2(160, 160);

    private Vector3 startSize;
    private Sprite startSprite;
    private bool isLerp = false;
    private float _timeStartedLerping;
    private Color endColor;
    private Color startColor;
    private float actTime = 0;


    void Start()
    {

        selected = false;

        switch(transitionOption) {

            case TransitionOption.sprite:
                startSprite = gameObject.GetComponent<Image>().sprite;
                break;
            case TransitionOption.size:
                startSize = fadeObj.GetComponent<RectTransform>().sizeDelta;
                break;
            
            case TransitionOption.alpha:
                fadeObj = gameObject;
                startColor = fadeObj.GetComponent<Image>().color;
                endColor = startColor;
                break;
            case TransitionOption.fill:
                startColor = fadeObj.GetComponent<Image>().color;
                endColor = startColor;
                break;
        }
    }

    void FixedUpdate()
    {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / slow;

            switch (transitionOption)
            {
                case TransitionOption.fill:
                    fadeObj.GetComponent<Image>().color = Color.Lerp(startColor, endColor, percentageComplete);
                    break;
            }

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
        }
    }

    public void Activate()
    {



        switch (transitionOption) {

            case TransitionOption.sprite: 

                switchImage(endSprite);
                break;
            
            case TransitionOption.alpha:
                switchColor();
                _timeStartedLerping = Time.time;
                isLerp = true;
               
                break;
            case TransitionOption.fill:
                switchColor();
                _timeStartedLerping = Time.time;
                isLerp = true;

                break;
        }

        selected = true;
    }

    public void Deactivate()
    {

        switch (transitionOption)
        {

            case TransitionOption.sprite:

                switchImage(startSprite);
                break;
            case TransitionOption.alpha:
                switchColor();
                _timeStartedLerping = Time.time;
                isLerp = true;

                break;
            case TransitionOption.fill:
                switchColor();
                _timeStartedLerping = Time.time;
                isLerp = true;

                break;
        }

        selected = false;
    }

    void switchImage(Sprite tSprite)
    {

        gameObject.GetComponent<Image>().sprite = tSprite;
    }

    void switchColor()
    {

        if (selected)
        {
            startColor.a = 1.0f;
            endColor.a = 0.0f;
        }
        else
        {
            startColor.a = 0.0f;
            endColor.a = 1.0f;
        }
    }
}