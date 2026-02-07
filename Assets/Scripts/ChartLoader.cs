using UnityEngine;
using System.Collections.Generic;

public class ChartLoader : MonoBehaviour
{
    public TextAsset chartFile;

    public List<NoteData> Notes { get; private set; }

    private void Awake()
    {
        ChartData data = JsonUtility.FromJson<ChartData>(chartFile.text);
        Notes = data.notes;
    }
}
