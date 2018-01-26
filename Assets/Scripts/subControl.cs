using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subControl : MonoBehaviour {

	// Use this for initialization

    public float scrollSpeed = 1.0f;
    public bool open{

        set;
        get;
    }
    Vector3 startPos, endPos;

    private bool isLerp = false;
    private float _timeStartedLerping;
	void Start () {

        open = false;
	}

    void FixedUpdate()
    {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / scrollSpeed;

            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos, endPos, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
        }

       
    }
	
    public void displaySubs() {

        open = open ? false : true;

        if (open) {

            //TODO Open Subs
        } else {

            //TODO Close Subs
        }
    }

    public void activateSubs() {

        if (open) {


        } else {
            
            resetSubs();
            startPos = new Vector3(0, 0, 0);
            endPos = new Vector3(-1 * gameObject.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

            _timeStartedLerping = Time.time;
            isLerp = true;
        }
    }

    public void resetSubs() {

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }
}
