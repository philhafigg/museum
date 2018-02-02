using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subControl : MonoBehaviour {

	// Use this for initialization

    public float scrollSpeed;
    public bool open;
    Vector3 startPos, endPos;
    private bool isLerp = false;
    private float _timeStartedLerping;
    private float calcSpeed;

	void Start () {

        open = false;
	}

    void FixedUpdate()
    {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / calcSpeed;

            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos, endPos, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
                resetSubs(2);
            }
        }
    }
	
    public void displaySubs() {

        if (open) {

            //TODO Close Subs
        } else {

            //TODO Open Subs
            activateSubs();
        }

        open = open ? false : true;
    }
    
    public void activateSubs() {

        if (open) {


        } else {

            resetSubs(0);
            startPos = new Vector3(0, 0, 0);
            //normalize speed
            calcSpeed = gameObject.GetComponent<RectTransform>().sizeDelta.x / scrollSpeed;

            endPos = new Vector3(-1 * gameObject.GetComponent<RectTransform>().sizeDelta.x, 0, 0);
            Debug.Log(gameObject.GetComponent<RectTransform>().sizeDelta.x);
            _timeStartedLerping = Time.time;
            isLerp = true;
        }
    }

    public void resetSubs(int seconds) {

        StartCoroutine(WaitTillReset(seconds));
    }

    IEnumerator WaitTillReset(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }
}
