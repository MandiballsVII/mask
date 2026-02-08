using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRowUI : MonoBehaviour
{
    public TMP_Text posText;
    public TMP_Text nameText;
    public TMP_Text scoreText;

    public TMP_InputField nameInput; // NUEVO

    // ---------------------------------

    public void SetupReadOnly(int pos, string name, int score)
    {
        posText.text = pos.ToString();
        nameText.text = name;
        scoreText.text = score.ToString();

        nameText.gameObject.SetActive(true);
        nameInput.gameObject.SetActive(false);
    }

    // ---------------------------------

    public void SetupEditable(int pos, int score, System.Action<string> onConfirm)
    {
        posText.text = pos.ToString();
        scoreText.text = score.ToString();

        nameText.gameObject.SetActive(false);
        nameInput.gameObject.SetActive(true);

        nameInput.text = "";
        nameInput.characterLimit = 3;

        nameInput.onSubmit.RemoveAllListeners();
        nameInput.onSubmit.AddListener(s => onConfirm(s));

        nameInput.ActivateInputField(); // foco automático
    }

    // ---------------------------------

    public void ConvertToText(string finalName)
    {
        nameInput.gameObject.SetActive(false);
        nameText.gameObject.SetActive(true);
        nameText.text = finalName;
    }
}
