using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColidInteractable : MonoBehaviour, myInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] GameObject button;
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
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.Rightinteract(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("contacted");
        return true;
    }
    bool myInteractable.loseContact(MyInteractor interactor)
    {
        button.GetComponent<Renderer>().material.color = Color.white;
        return true;
    }
}
