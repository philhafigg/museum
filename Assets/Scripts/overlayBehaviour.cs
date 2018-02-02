using UnityEngine;
using System.Collections;

public class overlayBehaviour : MonoBehaviour
{
	//gets called by gui controll - when clicked on another object or info
	public void Deactivate()
	{

        if (gameObject.GetComponent<clickBehaviour>()) {

            gameObject.GetComponent<clickBehaviour>().Deactivate();
        }

	}
}
