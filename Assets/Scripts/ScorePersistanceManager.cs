using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScorePersistenceManager : MonoBehaviour
{
    public static ScorePersistenceManager instance;

    string SavePath => Path.Combine(Application.persistentDataPath, "leaderboard.json");

    public List<ScoreEntry> scores = new();

    // Score temporal de la partida recién terminada
    public int lastScore = -1;

    const int MAX_SCORES = 10;

    // --------------------------------------------------
    // INIT
    // --------------------------------------------------

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --------------------------------------------------
    // PUBLIC API
    // --------------------------------------------------

    public void SubmitScore(int score)
    {
        lastScore = score;
    }

    public List<ScoreEntry> GetScores()
    {
        return scores;
    }

    public void AddScore(string name, int score)
    {
        scores.Add(new ScoreEntry(name, score));

        // ordenar DESC
        scores.Sort((a, b) => b.score.CompareTo(a.score));

        // limitar top 10
        if (scores.Count > MAX_SCORES)
            scores.RemoveRange(MAX_SCORES, scores.Count - MAX_SCORES);

        Save();

        lastScore = -1;
    }

    public bool IsHighScore(int score)
    {
        if (scores.Count < MAX_SCORES) return true;

        return score > scores[scores.Count - 1].score;
    }

    // --------------------------------------------------
    // SAVE / LOAD
    // --------------------------------------------------

    void Save()
    {
        LeaderboardData data = new LeaderboardData();
        data.scores = scores;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SafePath(), json);
    }

    void Load()
    {
        string path = SafePath();

        if (!File.Exists(path))
        {
            CreateTestData();
            Save();
            return;
        }

        string json = File.ReadAllText(path);
        LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);

        scores = data.scores ?? new List<ScoreEntry>();
    }

    string SafePath()
    {
        Directory.CreateDirectory(Application.persistentDataPath);
        return SavePath;
    }

    // --------------------------------------------------
    // TEST DATA (solo primera vez)
    // --------------------------------------------------

    void CreateTestData()
    {
        scores = new List<ScoreEntry>
        {
            new("AAA", 120000),
            new("DEV", 95000),
            new("BOT", 80000),
            new("ZED", 72000),
            new("LUA", 60000),
            new("MAX", 45000),
            new("ION", 40000),
            new("PIX", 32000),
            new("CPU", 20000),
            new("YOU", 10000)
        };
    }
}

[System.Serializable]
public class LeaderboardData
{
    public List<ScoreEntry> scores;
}

[System.Serializable]
public class ScoreEntry
{
    public string player;
    public int score;

    public ScoreEntry(string n, int s)
    {
        player = n;
        score = s;
    }
}
