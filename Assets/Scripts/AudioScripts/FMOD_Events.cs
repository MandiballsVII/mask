using UnityEngine;
using FMODUnity;

public class FMOD_Events : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference MainMenu { get; private set; }

    [field: SerializeField] public EventReference GameplayMusic { get; private set; }

    [field: Header("Menu Sounds")]
    [field: SerializeField] public EventReference ButtonSounds { get; private set; }

    [field: Header("ComboSFX")]
    [field: SerializeField] public EventReference NewCombo { get; private set; }
    [field: SerializeField] public EventReference LoseCombo { get; private set; }

    [field: Header("Misc")]
    [field: SerializeField] public EventReference FailInput { get; private set; }



    public static FMOD_Events instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Another FMOD_Events was found in this scene!");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
