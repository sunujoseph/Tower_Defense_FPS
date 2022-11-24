using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // message displayed to player when looking at object
    public string promptMessage;

    // called from player
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // no code here
        // template function will be overridden by other subclasses
    }

}
