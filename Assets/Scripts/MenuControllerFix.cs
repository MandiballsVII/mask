using UnityEngine;
using UnityEngine.EventSystems;

public class MenuControllerFix : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelPrincipal;
    public GameObject panelOptions;

    [Header("Botons para el foco (Mando)")]
    public GameObject firstButtonMenu;
    public GameObject firstButtonOptions;
    public GameObject OpenButtonOptions;

    public void OpenOptions ()
    {
        panelOptions.SetActive(true);
        panelPrincipal.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButtonMenu);
    }
    public void CloseOptions()
    {
        panelOptions.SetActive(false);
        panelPrincipal.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OpenButtonOptions);
    }

    public void ExitGame() {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel"))
        {
            if (panelOptions.activeSelf)
            {
                CloseOptions();
            }
        }
    }
}
