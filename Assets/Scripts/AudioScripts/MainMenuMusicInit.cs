using UnityEngine;

public class MainMenuMusicInit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.InitializeMusic(FMOD_Events.instance.MainMenu);
        Debug.Log("MusicaInicializada, supuestamente");
    }

}
