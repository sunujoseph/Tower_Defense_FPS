using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;

    // message displayed to player when looking at object
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

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
