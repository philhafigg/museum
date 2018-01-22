using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateDeactivate : MonoBehaviour {

    [Tooltip("Gets activated or deactivated. If it has blendinout it blends")]
    public GameObject activationObj;
    public GameObject[] deactivationObj;
    private bool blendInOutMesh = false;

    private bool selected = false;

	void Start () {

        gameObject.GetComponent<Button>().onClick.AddListener(() => gameObject.GetComponent<activateDeactivate>().selection());
	}

    void selection()
    {

        if (activationObj.GetComponent<blendInOut>() && !activationObj.GetComponent<blendInOut>().actBlend)
        {

            activationObj.GetComponent<blendInOut>().blend(true);
            deactivateObjects();
        }
        else if (activationObj.GetComponent<blendInOut>() && activationObj.GetComponent<blendInOut>().actBlend)
        {

            activationObj.GetComponent<blendInOut>().blend(false);
        }
        else if (activationObj.activeSelf)
        {

            activationObj.SetActive(false);
        }
        else {

            activationObj.SetActive(true);
            deactivateObjects();
        }
    }

    void deactivateObjects() {

        foreach(GameObject tObj in deactivationObj) {

            if (tObj.GetComponent<blendInOut>())
            {

                tObj.GetComponent<blendInOut>().blend(false);
            }
            else
            {

                tObj.SetActive(false);
            }
        }
    }
}
