using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.UI;
using Unity.XR.CoreUtils;

public class MyRayInteractable: MonoBehaviour
{
    //set hightlight color
    [SerializeField] private Color selectionOutlineColor = new Color(0.5f, 0.5f, 1.0f);
    //get to the parents.
    [SerializeField] private GameObject toselect;
    private GameObject parent;
    //get the control panel
    private GameObject cPanel;

    private void setup()
    {
        parent = toselect.transform.parent.gameObject;
        cPanel = parent.gameObject.transform.Find("control panel (1)").gameObject;
    }

    public bool SelectObj()
    {
        setup();
        //when select enable control panel and set ridge body kinematic
        toselect.GetComponent<Rigidbody>().isKinematic = true;
        cPanel.SetActive(true);
        return true;
    }

    public bool diSelectObj()
    {
        //diselect, cancle high light
        setup ();
        toselect.GetComponent<Rigidbody>().isKinematic = false;
        cPanel.SetActive(false);
        return true;
    }

    public bool destroyObj()
    {
        //diselect, cancle high light
        setup();
        Destroy(parent);
        return true;
    }
}
