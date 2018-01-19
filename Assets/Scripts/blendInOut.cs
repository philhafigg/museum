using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blendInOut : MonoBehaviour {

    Color tColor, startColor, endColor;
    public float slow = 0.7f; 
    float _timeStartedLerping;
    bool isLerp = false;
    public Component[] renderers;
    bool actBlend = true;
    public float destAlpha = 0.0f;
    private float endAlpha, startAlpha;
    public bool isUI = false;
    public bool isMesh = false;


    // Use this for initialization
    void Start () {

        if (isUI) {

            renderers = gameObject.GetComponentsInChildren<Image>();
        } 

        if (isMesh) {

            renderers = gameObject.GetComponentsInChildren<Renderer>();
        }

        startAlpha = tColor.a;  
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted;

            if (isUI)
            {

                foreach (Image renderer in renderers)
                {
                    tColor = renderer.color;

                    startColor = new Color(tColor.r, tColor.g, tColor.b, startAlpha);
                    endColor = new Color(tColor.r, tColor.g, tColor.b, endAlpha);

                    renderer.color = Color.Lerp(startColor, endColor, percentageComplete / slow);
                }
            }

            if (isMesh)
            {

                foreach (Renderer renderer in renderers)
                {
                    tColor = renderer.material.color;

                    startColor = new Color(tColor.r, tColor.g, tColor.b, startAlpha);
                    endColor = new Color(tColor.r, tColor.g, tColor.b, endAlpha);

                    renderer.material.color = Color.Lerp(startColor, endColor, percentageComplete / slow);
                }
            }

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
        }
    }
    //1 is in 0 is out
    public void blend(bool blendMode) {

        if (blendMode != actBlend) {
           
            if (blendMode)
            {
                startAlpha = destAlpha;
                endAlpha = 1.0f;
            }
            else {
                startAlpha = 1.0f;
                endAlpha = destAlpha;
            }
            actBlend = blendMode;
            isLerp = true;
            _timeStartedLerping = Time.time;
        }
    }
}
