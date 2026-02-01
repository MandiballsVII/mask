using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Actual Score")]
    public int totalScore = 0;
    public int actualCombo = 0;

    public int multiplicator = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    public float gameTime = 3f;

    public float timeToMainMenu = 10f;

    public ParticleSystem confetti;
    public ParticleSystem confetti2;
    public ParticleSystem confetti3;
    public ParticleSystem confetti4;

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else {
           Destroy(gameObject); 
        }
        //confetti.gameObject.SetActive(true);
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
        if(gameTime < 0)
        {
            PlayEndAnimation();
            timeToMainMenu -= Time.deltaTime;
            if(timeToMainMenu < 0)
            {
                AudioManager.instance.StopMusic();
                AudioManager.instance.ChangeScene("MainMenu");
            }
        }

    }

    private void PlayEndAnimation()
    {
        if (confetti != null)
            confetti.gameObject.SetActive(true);
        if (confetti2 != null)
            confetti2.gameObject.SetActive(true);
        if(confetti3 != null)
            confetti3.gameObject.SetActive(true);
        if (confetti4 != null)
            confetti4.gameObject.SetActive(true);
        
        //if(totalScore < 2000)
        //{
        //    PlayBadEnd();
        //}
        //else if(totalScore > 2001 && totalScore < 5000)
        //{
        //    PlayMiddleEnd();
        //}
        //else
        //{
        //    PlayGoodEnd();
        //}
    }

    private void PlayGoodEnd()
    {
        throw new NotImplementedException();
    }

    private void PlayMiddleEnd()
    {
        throw new NotImplementedException();
    }

    private void PlayBadEnd()
    {
        throw new NotImplementedException();
    }

    public void AddScore(int pointsBase) {
            actualCombo++;

            if (actualCombo >= 20) {
                multiplicator = 4;
            } else if (actualCombo >= 10) {
                multiplicator = 2;
            } else {
                multiplicator = 1;
            }

            totalScore += pointsBase * multiplicator;

            Debug.Log(message: $"Puntos: {totalScore} | Combo: {actualCombo} | Multi: x{multiplicator}");
            UpdateInterface();
            
        }

    public void UpdateInterface() {
        scoreText.SetText("Score: {0}", totalScore);
        comboText.SetText("x{0}", actualCombo);
    }

    public void ResetCombo() {
        if(multiplicator != 1)
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