using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleDown : MonoBehaviour, myInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] GameObject button;
    [SerializeField] GameObject refObj;
    [SerializeField] float scaleFactor = 0.5f;
    string myInteractable.InteractionPrompt => _prompt;

    bool myInteractable.interact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.yellow;
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.Leftinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.green;
        if (refObj.transform.localScale.x - scaleFactor > 0)
        {
            refObj.transform.localScale = refObj.transform.localScale - new Vector3(scaleFactor, scaleFactor, scaleFactor);
            refObj.transform.position = new Vector3(refObj.transform.position.x, refObj.transform.position.y * scaleFactor + 0.05f, refObj.transform.position.z);
        }
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.Rightinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.green;
        if (refObj.transform.localScale.x- scaleFactor > 0)
        {
            refObj.transform.localScale = refObj.transform.localScale - new Vector3(scaleFactor, scaleFactor, scaleFactor);
            refObj.transform.position = new Vector3(refObj.transform.position.x, refObj.transform.position.y * scaleFactor+0.05f, refObj.transform.position.z);
        }
        
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.loseContact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.white;
        return true;
    }
}
