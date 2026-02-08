using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{
    [Header("Refs")]
    public LeaderboardService service;
    public LeaderboardUI ui;

    [Header("UI")]
    public GameObject startMessage;

    [Header("Input")]
    public InputActionReference startAction;

    List<ScoreEntry> currentScores = new();

    int playerScore;
    int playerIndex = -1;

    bool canExit = false;

    ScoreRowUI playerRow;

    // -------------------------------------------------

    void Start()
    {
        startAction.action.Enable();
        startAction.action.performed += OnStartPressed;

        playerScore = GameSession.instance.ConsumeScore();

        service.GetTopScores(OnScoresDownloaded);

        startMessage.SetActive(false);
        canExit = false;
    }

    // -------------------------------------------------

    void OnScoresDownloaded(string json)
    {
        ScoreEntry[] entries = JsonHelper.FromJson<ScoreEntry>(json);
        currentScores = new List<ScoreEntry>(entries);

        playerIndex = GetInsertIndex(playerScore);

        DrawUI();
    }

    // -------------------------------------------------

    void DrawUI()
    {
        ui.Clear();

        for (int i = 0; i < Mathf.Max(currentScores.Count, 10); i++)
        {
            ScoreRowUI row = ui.AddRow();

            //FILA EDITABLE (jugador entra en ranking)
            if (i == playerIndex)
            {
                playerRow = row;

                row.SetupEditable(i + 1, playerScore, ConfirmName);

                canExit = false;
                startMessage.SetActive(false);
                continue;
            }

            //FILA NORMAL
            if (i < currentScores.Count)
            {
                row.SetupReadOnly(
                    i + 1,
                    currentScores[i].player,
                    currentScores[i].score
                );
            }
            else
            {
                row.SetupReadOnly(i + 1, "---", 0);
            }
        }

        //Si NO entra en ranking -> puede salir directamente
        if (playerIndex == -1)
        {
            canExit = true;
            startMessage.SetActive(true);
        }
    }

    // -------------------------------------------------

    int GetInsertIndex(int score)
    {
        if (score < 0) return -1;

        for (int i = 0; i < currentScores.Count; i++)
            if (score > currentScores[i].score)
                return i;

        if (currentScores.Count < 10)
            return currentScores.Count;

        return -1;
    }

    // -------------------------------------------------

    void ConfirmName(string name)
    {
        name = name.ToUpper();

        service.SubmitScore(name, playerScore);

        //convierte la fila editable a texto normal
        playerRow.ConvertToText(name);

        //ahora sí puede salir
        canExit = true;
        startMessage.SetActive(true);
    }

    // -------------------------------------------------

    void OnStartPressed(InputAction.CallbackContext ctx)
    {
        if (!canExit) return;
        AudioManager.instance.PlayOneShot(FMOD_Events.instance.FailInput);
        SceneManager.LoadScene("MainMenu");
    }
}
