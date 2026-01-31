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
    [field: SerializeField] public EventReference X2 { get; private set; }
    [field: SerializeField] public EventReference X3 { get; private set; }
    [field: SerializeField] public EventReference X4 { get; private set; }
    [field: SerializeField] public EventReference X5 { get; private set; }
    [field: SerializeField] public EventReference LoseCombo { get; private set; }

    [field: Header("Misc")]
    [field: SerializeField] public EventReference FailInput { get; private set; }

    [field: SerializeField] public EventReference Metronome { get; private set; }


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
