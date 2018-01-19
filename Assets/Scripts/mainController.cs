using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class mainController : MonoBehaviour {

    public bool trackFound = false;
    public string target;
    private GameObject targetObject = null;
    public GameObject GUI;

    private GameObject selectedObj;

    //gets called by vuforia
    public void setTracking(bool track, string target) {

        trackFound = track;

        if (trackFound) {

            this.target = target;

            if (targetObject) {

                targetObject.SetActive(false);
            }

            GUI.GetComponent<GuiControll>().activateSection(target);

            if (GameObject.Find("ImageTarget_" + target) && GameObject.Find("ImageTarget_" + target).transform.Find("TargetActivation")) {

                targetObject = GameObject.Find("ImageTarget_" + target).transform.Find("TargetActivation").gameObject;
                targetObject.SetActive(true);
            }
        } else {

            GUI.GetComponent<GuiControll>().deactivateSection(target);
        }
    }
    //activate Clicked Element - subitems gui
    public void activateElement(string eleStr) {

        if (selectedObj) {

            selectedObj.SetActive(false);
        }

        string[] substrings = eleStr.Split(new string[] { "Layer" }, StringSplitOptions.None);
        string layer = substrings[0] + "Layer";

        selectedObj = GameObject.Find(layer).transform.Find(eleStr).gameObject;

        selectedObj.SetActive(true);
    }

    void setActive() {


    }

    void setInActive() {


    }

    public void lockModel() {

        //GameObject imageTarget = GameObject.Find("ImageTarget");

        //imageTarget.GetComponent<ImageTargetBehaviour>();
        //imageTarget.


        //1
        /*
        GameObject imageTarget = GameObject.Find("ImageTarget");
        Transform[] ts = imageTarget.GetComponentsInChildren<Transform>();

        if (imageTarget == null || ts == null)
        {

            return;
        }

        foreach (Transform t in ts)
        {
            if (t != null)
            {

                if (t.parent == imageTarget.transform)
                {

                    t.parent = null;
                }
            }
        }

      

        foreach (Transform t in ts)
        {

            MeshRenderer tMr = t.gameObject.GetComponent<MeshRenderer>();
            tMr.enabled = true;
        }


        /*
         * 2
        GameObject imageTarget = GameObject.Find("ImageTarget");
        GameObject arCam = GameObject.Find("ARCamera");
        Transform[] ts = imageTarget.GetComponentsInChildren<Transform>();

        if (imageTarget == null || ts == null || arCam == null) {

            return;
        }

        foreach (Transform t in ts) {
            if (t != null) {

                if (t.parent == imageTarget.transform)
                {

                    t.SetParent(arCam.transform);
                }
            }
        }

        MeshRenderer[] mr = arCam.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer tMr in mr)
        {

            tMr.enabled = true;
        }
*/
        //CameraDevice.Instance.Stop();
        //ObjectTracker imgTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        //imgTracker.Stop();
    }

    public void unLockModel() {


    }
}
