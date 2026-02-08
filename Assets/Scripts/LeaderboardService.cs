using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardService : MonoBehaviour
{
    const string BASE_URL = "https://nrzgrwbqltmhibwqzyrq.supabase.co/rest/v1/scores";
    const string APIKEY = "sb_publishable_Gg_3Sns7M6wqkeH7_4Rr8Q_0_6sHz5m";

    // =========================
    // SUBIR SCORE
    // =========================
    public void SubmitScore(string name, int score)
    {
        StartCoroutine(SubmitRoutine(name, score));
    }

    IEnumerator SubmitRoutine(string name, int score)
    {
        string json = $"{{\"player\":\"{name}\",\"score\":{score}}}";

        UnityWebRequest req = new UnityWebRequest(BASE_URL, "POST");

        byte[] body = Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("apikey", APIKEY);
        req.SetRequestHeader("Authorization", "Bearer " + APIKEY);
        req.SetRequestHeader("Prefer", "return=minimal");

        yield return req.SendWebRequest();
    }

    // =========================
    // DESCARGAR TOP 10
    // =========================
    public void GetTopScores(System.Action<string> callback)
    {
        StartCoroutine(GetRoutine(callback));
    }

    IEnumerator GetRoutine(System.Action<string> callback)
    {
        string query = BASE_URL + "?select=player,score&order=score.desc&limit=10";

        UnityWebRequest req = UnityWebRequest.Get(query);

        req.SetRequestHeader("apikey", APIKEY);
        req.SetRequestHeader("Authorization", "Bearer " + APIKEY);

        yield return req.SendWebRequest();

        callback?.Invoke(req.downloadHandler.text);
    }
}
