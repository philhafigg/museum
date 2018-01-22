using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;
using SimpleJSON;


public class mainController : MonoBehaviour
{

    public bool trackFound = false;
    public string target, jsonFile;
    private GameObject targetObject = null;
    public GameObject GUI;
    public JSONNode jsonNode;
    private GameObject selectedObj;
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    private void Start()
    {
        loadGameData();
    }

    //gets called by vuforia
    public void setTracking(bool track, string target)
    {

        trackFound = track;

        if (trackFound)
        {

            this.target = target;

            if (targetObject)
            {

                targetObject.SetActive(false);
            }

            GUI.GetComponent<GuiControll>().activateSection(target);

            if (GameObject.Find("ImageTarget_" + target) && GameObject.Find("ImageTarget_" + target).transform.Find("TargetActivation"))
            {

                targetObject = GameObject.Find("ImageTarget_" + target).transform.Find("TargetActivation").gameObject;
                targetObject.SetActive(true);
            }
        } else
        {

            GUI.GetComponent<GuiControll>().deactivateSection(target);
        }
    }
    //activate Clicked Element - subitems gui
    public void activateElement(string eleStr)
    {

        if (selectedObj)
        {
            selectedObj.SetActive(false);
        }

        string[] substrings = eleStr.Split(new string[] { "Layer" }, StringSplitOptions.None);
        string layer = substrings[0] + "Layer";

        selectedObj = GameObject.Find(layer).transform.Find(eleStr).gameObject;

        selectedObj.SetActive(true);
    }

    void loadGameData()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {

            string dataAsJson = File.ReadAllText(filePath);
            jsonNode = JSON.Parse(dataAsJson);
        }
    }

    public string getText(string id) {

        return jsonNode[id];
    }

}