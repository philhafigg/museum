using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blendInOut : MonoBehaviour {


    public float slow = 0.7f; 
    public bool isUI = false;
    public bool isMesh = false;
    public bool actBlend;
    public Component[] imageRenderers, meshRenderers;
    public float destAlpha = 0.0f;

    private float endAlpha, startAlpha;
    private Color tColor, startColor, endColor;
    private bool isLerp = false;
    private float _timeStartedLerping;

    // Use this for initialization
    void Start () {

        if (isUI) {

            imageRenderers = gameObject.GetComponentsInChildren<Image>();

            if (!actBlend) {

                foreach (Image renderer in imageRenderers)
                {
                    tColor = renderer.color;
                    tColor.a = 0;
                    renderer.color = tColor;
                }
            }
        } 

        if (isMesh) {

            meshRenderers = gameObject.GetComponentsInChildren<Renderer>();
            if (!actBlend)
            {

                foreach (Image renderer in meshRenderers)
                {
                    tColor = renderer.material.color;
                    tColor.a = 0;
                    renderer.material.color = tColor;
                }
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted;

            if (isUI)
            {

                foreach (Image renderer in imageRenderers)
                {
                    tColor = renderer.color;

                    startColor = new Color(tColor.r, tColor.g, tColor.b, startAlpha);
                    endColor = new Color(tColor.r, tColor.g, tColor.b, endAlpha);

                    renderer.color = Color.Lerp(startColor, endColor, percentageComplete / slow);
                }
            }

            if (isMesh)
            {

                foreach (Renderer renderer in meshRenderers)
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
