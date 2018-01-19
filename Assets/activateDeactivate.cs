using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateDeactivate : MonoBehaviour {

    [Tooltip("Gets activated or deactivated. If it has blendinout it blends")]
    public GameObject tObj;
    private bool blendInOutMesh = false;

    private bool selected = false;

	void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(() => gameObject.GetComponent<activateDeactivate>().selection());
	}

    void selection () {

        if (selected) {
               
            if (tObj.GetComponent<blendInOut>()) {

                tObj.GetComponent<blendInOut>().blend(false);
            } else {

                tObj.SetActive(false);
            }

            selected = false;
        } else {

            if (tObj.GetComponent<blendInOut>())
            {

                tObj.GetComponent<blendInOut>().blend(true);
            }
            else
            {

                tObj.SetActive(true);
            }

            selected = true;
        }
    }
}
