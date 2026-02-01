using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif 
    }

    public void StopMusic()
    {
        AudioManager.instance.StopMusic();
    }

    public void PlayButtonSFX()
    {
        AudioManager.instance.PlayOneShot(FMOD_Events.instance.ButtonSounds);
    }
}
