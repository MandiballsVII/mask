using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession instance;

    public int finalScore = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetFinalScore(int score)
    {
        finalScore = score;
    }

    public int ConsumeScore()
    {
        int s = finalScore;
        finalScore = -1; // limpiar después de usar
        return s;
    }
    public void Clear()
    {
        finalScore = -1;
    }
}
