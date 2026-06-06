using UnityEditor;
[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("This Interactable only uses events.", MessageType.Info);
            if(interactable.GetComponent<InteractableEvent>() == null)
            {
                interactable.useEvent = true;
                interactable.gameObject.AddComponent<InteractableEvent>();
            }
        }

        else
        {

            base.OnInspectorGUI();
            if (interactable.useEvent)
            {
                if (interactable.gameObject.GetComponent<InteractableEvent>() == null)
                {
                    interactable.gameObject.AddComponent<InteractableEvent>();
                }
            }
            else
            {
                if (interactable.gameObject.GetComponent<InteractableEvent>() != null)
                {
                    DestroyImmediate(interactable.gameObject.GetComponent<InteractableEvent>());
                }
            }
        }

    }   
}
