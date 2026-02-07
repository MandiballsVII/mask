using UnityEngine;

public class MainMenuMusicInit : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.InitializeMusic(FMOD_Events.instance.MainMenu);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
