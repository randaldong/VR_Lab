using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zneg : MonoBehaviour, myInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] GameObject button;
    [SerializeField] GameObject refObj;
    [SerializeField] float movingStep = 0.1f;
    string myInteractable.InteractionPrompt => _prompt;

    bool myInteractable.interact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.yellow;
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.Leftinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.red;
        Quaternion rotationIncrement = Quaternion.AngleAxis(-movingStep *3f, Vector3.up);
        refObj.transform.rotation = refObj.transform.rotation * rotationIncrement;
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.Rightinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.blue;
        refObj.transform.position = refObj.transform.position + new Vector3(0f, 0f, -movingStep);
        return true;
    }
    bool myInteractable.loseContact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.white;
        return true;
    }
}