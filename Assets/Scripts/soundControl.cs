using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour {

    public mainController mainControl;

    private string lang;
    private bool muted = false;

	// Use this for initialization
	void Start () {

        lang = mainControl.lang;
	}

    public void mute()
    {
        gameObject.GetComponent<AudioSource>().mute = muted ? false : true;
        muted = muted ? false : true;
    }

    public void playSound(string tSound) {
        
        AudioClip clip1 = (AudioClip)Resources.Load("Sounds/" + tSound + "_" + lang ) as AudioClip;
        gameObject.GetComponent<AudioSource>().clip = clip1;
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip1);
    }

    public void stopSound() {

        gameObject.GetComponent<AudioSource>().Stop();
    }
}
