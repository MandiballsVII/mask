using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeepSelection : MonoBehaviour
{
    private GameObject lastSelected;

    void Update() {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            lastSelected = EventSystem.current.currentSelectedGameObject;
        } else {
            if (lastSelected != null) {
                EventSystem.current.SetSelectedGameObject(lastSelected);
            }
        }
    }
}
