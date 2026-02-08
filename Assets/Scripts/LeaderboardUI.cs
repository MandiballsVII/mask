using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject rowPrefab;

    public void Clear()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);
    }

    public ScoreRowUI AddRow()
    {
        GameObject row = Instantiate(rowPrefab, contentParent);
        return row.GetComponent<ScoreRowUI>();
    }
}
