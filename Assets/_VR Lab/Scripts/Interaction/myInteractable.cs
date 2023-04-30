using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface myInteractable
{
    public string InteractionPrompt { get; }
    public bool interact(MyInteractor interactor);
    public bool Leftinteract(MyInteractor interactor);
    public bool Rightinteract(MyInteractor interactor);
    public bool loseContact(MyInteractor interactor); 
}
