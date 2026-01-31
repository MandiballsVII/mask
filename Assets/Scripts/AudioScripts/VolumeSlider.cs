using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,
        MUSIC,
        SFX
    }

    [Header("Type")]
    [SerializeField] private VolumeType Volumetype;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        switch (Volumetype) 
        { 
            case VolumeType.MASTER:
                volumeSlider.value = AudioManager.instance.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioManager.instance.musicVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.instance.sfxVolume;
                break;
            default:
                Debug.LogWarning("Volume type not supporterd");
                break;
        }
    }

    public void OnSliderValueChange()
    {
        switch (Volumetype)
        {
            case VolumeType.MASTER:
                AudioManager.instance.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.instance.musicVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.instance.sfxVolume = volumeSlider.value;
                break;
            default:
                Debug.LogWarning("Volume type not supporterd");
                break;
        }
    }
}
