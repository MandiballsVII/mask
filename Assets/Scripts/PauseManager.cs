using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    [Header("UI")]
    public CanvasGroup pauseCanvasGroup;
    public InputActionReference pauseAction;
    public bool IsPaused => isPaused;
    public bool isPaused = false;
    public GameObject firstButton;

    // -------------------------------------------------

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePause;
    }

    private void OnDisable()
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }
    private void TogglePause(InputAction.CallbackContext ctx)
    {
        if (isPaused) Resume();
        else Pause();
    }
    //private void Update()
    //{
    //    // Tecla ESC
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (isPaused)
    //            Resume();
    //        else
    //            Pause();
    //    }
    //}

    // -------------------------------------------------
    // PAUSE
    // -------------------------------------------------

    public void Pause()
    {
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);

        isPaused = true;
        AudioManager.instance.PauseMusic();
        Time.timeScale = 0f;

        pauseCanvasGroup.alpha = 1f;
        pauseCanvasGroup.interactable = true;
        pauseCanvasGroup.blocksRaycasts = true;
    }

    public void Resume()
    {
        isPaused = false;

        Time.timeScale = 1f;
        AudioManager.instance.ResumeMusic();
        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.interactable = false;
        pauseCanvasGroup.blocksRaycasts = false;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;

        AudioManager.instance.StopMusic();
        AudioManager.instance.ChangeScene("MainMenu");
    }
}
