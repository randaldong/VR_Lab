using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleUp : MonoBehaviour, myInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] GameObject button;
    [SerializeField] GameObject refObj;
    [SerializeField] float scaleFactor = 0.1f;
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
        refObj.transform.localScale = refObj.transform.localScale + new Vector3(scaleFactor, scaleFactor, scaleFactor);
        refObj.transform.position = new Vector3(refObj.transform.position.x, refObj.transform.position.y , refObj.transform.position.z);
        Debug.Log("upContacted");
        return true;
    }
    bool myInteractable.Rightinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.green;
        refObj.transform.localScale = refObj.transform.localScale + new Vector3(scaleFactor, scaleFactor, scaleFactor);
        refObj.transform.position = new Vector3(refObj.transform.position.x, refObj.transform.position.y * scaleFactor + 0.05f, refObj.transform.position.z);
        Debug.Log("upContacted");
        return true;
    }
    bool myInteractable.loseContact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.white;
        return true;
    }
}
