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

    public float gameTime = 145f;

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else {
           Destroy(gameObject); 
        }
     
    }
    private void Update()
    {
        gameTime -= Time.deltaTime;
        if(gameTime < 0)
        {
            PlayEndAnimation();
        }
    }

    private void PlayEndAnimation()
    {
        if(totalScore < 2000)
        {
            PlayBadEnd();
        }
        else if(totalScore > 2001 && totalScore < 5000)
        {
            PlayMiddleEnd();
        }
        else
        {
            PLayGoodEnd();
        }
    }

    private void PLayGoodEnd()
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
        actualCombo = 0;
        multiplicator = 1;

        UpdateInterface();
        Debug.Log(message: "Combo lost!");
    }
}