using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class GuiControll : MonoBehaviour
{

    private GameObject[] buttonList;
    public GameObject activeButton;
    public GameObject activeSection;
    public GameObject[] sectionList;
    public GameObject mainController;
    public GameObject GuiOverlay;
    public GameObject Loading;
    public GameObject sub;

    // Use this for initialization
    void Start()
    {
        getAllButtons();
        getAllSections();
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

            button.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GUI").GetComponent<GuiControll>().buttonPushed(button));
        }
    }

    void buttonPushed(GameObject button)
    {

        if (activeButton)
        {

            activeButton.GetComponent<guiTouchedAnimation>().selected = false;
        }

        if (button.GetComponent<guiTouchedAnimation>() != null)  {

            button.GetComponent<guiTouchedAnimation>().selected = true;
        }
       
        activeButton = button;
        //activateElement();
    }

    void activateElement()
    {

        string[] substrings = activeButton.name.Split(new string[] { "Button_" }, StringSplitOptions.None);
        mainController.GetComponent<mainController>().activateElement(substrings[1]);
    }

    public void activateSection(String section) {
        
        if (activeSection && activeSection.transform.name != section) {

            activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<Animator>().SetTrigger("completeReset");
        } 

        if (activeSection && activeSection.transform.name == section) {

            return;
        } else {

            Loading.SetActive(false);

            activeSection = gameObject.transform.FindDeepChild(section).gameObject;
            activeSection.SetActive(true);
            GuiOverlay.transform.FindDeepChild(section).gameObject.SetActive(true);
        }
    }

    public void selectOverlay(GameObject element) {

        sub.GetComponent<Text>().text = mainController.GetComponent<mainController>().getText(element.transform.name);
    }

    public void deactivateSection(string target){

        if (activeSection && activeSection.transform.name == target)
        {
           
            Loading.SetActive(true);
            GuiOverlay.transform.FindDeepChild(activeSection.transform.name).gameObject.SetActive(false);
            //activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<Animator>().SetTrigger("closeChildAnimation");
        }
    }

    public void resetSection() {
        //activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<Animator>().SetTrigger("closeChildAnimation");
        //activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<ResetChildAnimationMovement>().softReset();

        activeSection.SetActive(false);
        activeSection = null;
    }

    public void showInfo()
    {

        sub.GetComponent<Text>().text = mainController.GetComponent<mainController>().getText("info");
    }

}