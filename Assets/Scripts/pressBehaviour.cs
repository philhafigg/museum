using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class pressBehaviour : MonoBehaviour
{

    public int id;

    public List<DialogChoice> responses = new List<DialogChoice>();

    public bool pressed
    {

        set;
        get;
    }

    private void Awake()
    {
        pressed = false;
    }

    private void OnMouseEnter()
    {

        pressed = pressed ? false : true;
    }
}
