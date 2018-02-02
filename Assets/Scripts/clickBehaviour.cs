using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class clickBehaviour : MonoBehaviour
{

    public bool selected = false;
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
    public bool activeOnStartup;

    public UnityEvent activateEvent;
    public UnityEvent deactivateEvent;

    private Vector3 startSize;
    private Sprite startSprite;
    private bool isLerp = false;
    private float _timeStartedLerping;
    private Color startColor, endColor;

    void Start()
    {

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

        if (activeOnStartup) {

            Activate();
        } else {

            OnDeactivation();
        }
    }

    public void ActiveOnStartup() {
        
        Activate();
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
                case TransitionOption.alpha:
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
        Debug.Log(gameObject.name);

        if (!selected)
        {

            OnActivation();

            switch (transitionOption)
            {

                case TransitionOption.sprite:

                    switchImage(endSprite);
                    break;

                case TransitionOption.alpha:

                    switchAlpha();
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
    }

    public void Deactivate()
    {

        if (selected) {

            OnDeactivation();

            switch (transitionOption)
            {

                case TransitionOption.sprite:

                    switchImage(startSprite);
                    break;
                case TransitionOption.alpha:
                    switchAlpha();
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

    }

    void switchImage(Sprite tSprite)
    {

        gameObject.GetComponent<Image>().sprite = tSprite;
    }

    void switchAlpha()
    {
        if (selected)
        {
            endColor.a = startColor.a;
            startColor.a = 1.0f;
        }
        else
        {
            startColor.a = endColor.a;
            endColor.a = 1.0f;
        }
    }

    //TODO switch color not just alpha
    void switchColor()
    {
        if (selected)
        {
            endColor.a = startColor.a;
            startColor.a = 1.0f;
        }
        else
        {
            startColor.a = endColor.a;
            endColor.a = 1.0f;
        }
    }

    //extend this function;
    void OnActivation()
    {
        if (activateEvent != null)
        {
            activateEvent.Invoke();
        }
    }

    //extend this function;
    void OnDeactivation() {

        if (deactivateEvent != null) {

            deactivateEvent.Invoke();
        }
    }
}