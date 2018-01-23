using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

[Serializable]
public class DialogChoice
{

    [Serializable]
    public class ButtonClickedEvent : UnityEngine.Events.UnityEvent { }
    [FormerlySerializedAs("OnClick")]
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
}
