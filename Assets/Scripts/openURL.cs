using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour {

    public string defaultUrl;

    public void openUrl(string tUrl) {

        string url;

        if (tUrl != null && tUrl != "") {

            url = tUrl;
        } else {

            url = defaultUrl;
        }

        Application.OpenURL(url);
    }
}