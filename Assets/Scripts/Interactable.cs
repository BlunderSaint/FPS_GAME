using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    public bool useEvent;
    public string promptMessage;

    public void BaseInteract()
    {
        if(useEvent)
        {
            GetComponent<InteractableEvent>().onInteract.Invoke();
            Interact();
        }
    }
    protected virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
