using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Actual Score")]
    public int totalScore = 0;
    public int actualCombo = 0;
    public int multiplicator = 1;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI finalScoreText;
    public CanvasGroup scoreCanvasGroup;

    [Header("Timers")]
    public float gameTime = 145f;

    [Header("Fade")]
    public float fadeDuration = 2f;

    [Header("FX")]
    public ParticleSystem confetti;
    public ParticleSystem confetti2;
    public ParticleSystem confetti3;
    public ParticleSystem confetti4;

    [Header("Final objects")]
    public GameObject finalGas;
    public GameObject finalRock;
    public GameObject dj;

    private float endTimer = 0f;
    private bool endStarted = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreCanvasGroup.alpha = 0f;
        scoreCanvasGroup.interactable = false;
        scoreCanvasGroup.blocksRaycasts = false;
    }
    private void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.InitializeMusic(FMOD_Events.instance.GameplayMusic);
        }
        else
        {
            Debug.LogError("AudioManager NO existe");
        }
    }
    private void Update()
    {
        gameTime -= Time.deltaTime;

        // -------------------------------------------------
        // INICIO DEL FINAL (solo una vez)
        // -------------------------------------------------
        if (gameTime <= 0 && !endStarted)
        {
            endStarted = true;
            PauseManager.instance.SetPauseEnabled(false);
            PlayEndAnimation();
        }

        // -------------------------------------------------
        // SECUENCIA FINAL
        // -------------------------------------------------
        if (!endStarted) return;

        endTimer += Time.deltaTime;

        float fadeStart = 7f;
        float sceneChangeTime = 20f;

        // -------- Fade entre 10s y 12s --------
        if (endTimer >= fadeStart && endTimer <= fadeStart + fadeDuration)
        {
            float progress = (endTimer - fadeStart) / fadeDuration;
            scoreCanvasGroup.alpha = Mathf.SmoothStep(0f, 1f, progress);
        }

        // -------- Asegurar alpha final --------
        if (endTimer > fadeStart + fadeDuration)
        {
            scoreCanvasGroup.alpha = 1f;
        }

        // -------- Cambio de escena --------
        if (endTimer >= sceneChangeTime)
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.ChangeScene("MainMenu");
        }
    }

    private void PlayEndAnimation()
    {
        if (confetti) confetti.gameObject.SetActive(true);
        if (confetti2) confetti2.gameObject.SetActive(true);
        if (confetti3) confetti3.gameObject.SetActive(true);
        if (confetti4) confetti4.gameObject.SetActive(true);

        if (totalScore < 2000)
        {
            PlayBadEnd();
        }
        else if (totalScore > 2001 && totalScore < 5000)
        {
            PlayMiddleEnd();
        }
        else
        {
            PlayGoodEnd();
        }
    }

    private void PlayGoodEnd()
    {
        finalGas.SetActive(true);
        finalGas.GetComponent<Animator>().Play("FinalGas");
    }

    private void PlayMiddleEnd()
    {
        finalRock.SetActive(true);
        finalRock.GetComponent<Animator>().Play("finalRoca");
    }

    private void PlayBadEnd()
    {
        dj.GetComponent<Dj>().EndGame();
    }


    // -------------------------------------------------
    // SCORE
    // -------------------------------------------------

    public void AddScore(int pointsBase)
    {
        actualCombo++;

        if (actualCombo >= 20)
        {
            multiplicator = 4;
        }
        else if (actualCombo >= 10)
        {
            multiplicator = 2;
        }
        else
        {
            multiplicator = 1;
        }

        totalScore += pointsBase * multiplicator;

        Debug.Log(message: $"Puntos: {totalScore} | Combo: {actualCombo} | Multi: x{multiplicator}");
        UpdateInterface();

    }

    public void UpdateInterface()
    {
        scoreText.SetText("Score: {0}", totalScore);
        comboText.SetText("x{0}", actualCombo);
        finalScoreText.SetText("{0}", totalScore);
    }

    public void ResetCombo()
    {
        if (multiplicator != 1)
        {
            AudioManager.instance.PlayOneShot(FMOD_Events.instance.LoseCombo);
        }
        else
        {
            AudioManager.instance.PlayOneShot(FMOD_Events.instance.FailInput);
        }
        actualCombo = 0;
        multiplicator = 1;

        UpdateInterface();
        Debug.Log(message: "Combo lost!");
    }
}