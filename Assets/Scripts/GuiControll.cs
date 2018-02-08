using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text.RegularExpressions;
using System;

public class GuiControll : MonoBehaviour
{

    private overlayBehaviour[] overlayList;
    private GameObject[] buttonList;
    public GameObject activeButton;
    public GameObject activeSection;
    public GameObject[] sectionList;
    public GameObject mainController;
    public GameObject GuiOverlay;
    public GameObject Loading;
    public GameObject sub;
    public GameObject Audio;

    public GameObject[] activeOnStartUp;

    // Use this for initialization

    private void Awake()
    {
        //museum
        getAllOverlays();
    }

    void Start()
    {
        getAllButtons();
        getAllSections();

        activateActiveOnStartUp();
    }

    void getAllSections()
    {
        /*
        sectionList = GameObject.FindGameObjectsWithTag("GUI_Section");

        foreach (GameObject section in sectionList)
        {
           // section.SetActive(false);
        }
        */
    }

    void getAllButtons()
    {

        buttonList = GameObject.FindGameObjectsWithTag("GUI_Button");

        foreach (GameObject button in buttonList)
        {
            Debug.Log(button.transform.name);
            button.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GUI").GetComponent<GuiControll>().buttonPushed(button));
        }
    }

    void getAllOverlays()
    {

        overlayList = (overlayBehaviour[]) FindObjectsOfType(typeof(overlayBehaviour));
    }

    //executes Buttons on Startup
    void activateActiveOnStartUp() {


    }

    void buttonPushed(GameObject button)
    {
        if (button.GetComponent<clickBehaviour>().selected)
        {

            button.GetComponent<clickBehaviour>().Deactivate();
        }
        else
        {

            button.GetComponent<clickBehaviour>().Activate();
        }
    }

    public void activateSection(String section) {
        
        if (activeSection && activeSection.transform.name != section) {

            activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<Animator>().SetTrigger("completeReset");
        } 

        if (activeSection && activeSection.transform.name == section) {

            return;
        } else {

            Loading.GetComponent<blendInOut>().blend(false); 

            activeSection = gameObject.transform.FindDeepChild(section).gameObject;
            activeSection.SetActive(true);
            GuiOverlay.transform.FindDeepChild(section).gameObject.SetActive(true);
        }
    }

    public void selectOverlay(GameObject element) {
        
        foreach (overlayBehaviour overlay in overlayList)
        {
            Debug.Log(overlay.gameObject.transform.parent.transform.name);

            if (overlay.gameObject != element.gameObject && overlay.GetComponent<clickBehaviour>().selected == true) {

                overlay.Deactivate();
            }
        }
      
        sub.GetComponent<Text>().text = mainController.GetComponent<mainController>().getText(element.transform.name);
        StartCoroutine(acitvateSubs(element.transform.name));
    }

    public void showInfo()
    {
        foreach(overlayBehaviour overlay in overlayList) {

            overlay.Deactivate();
        }

        sub.GetComponent<Text>().text = mainController.GetComponent<mainController>().getText("info");
        StartCoroutine(acitvateSubs("info"));
    }

    IEnumerator acitvateSubs(String subName) {

        yield return new WaitForEndOfFrame();
        sub.GetComponent<subControl>().activateSubs();
        Audio.GetComponent<soundControl>().playSound(subName);
    }

    public void deactivateSection(string target){

        if (activeSection && activeSection.transform.name == target)
        {
            Loading.GetComponent<blendInOut>().blend(true); 
            GuiOverlay.transform.FindDeepChild(activeSection.transform.name).gameObject.SetActive(false);
            activeSection = null;
        }
    }

    public void resetSection() {

        activeSection.SetActive(false);
        activeSection = null;
    }

    public void showSubs(bool open) {
        
        if (open) {

            sub.SetActive(true);
            if (sub.GetComponent<Text>().text == "") {

                showInfo();
            }
        } else {

            sub.SetActive(false);
        }
    }

}