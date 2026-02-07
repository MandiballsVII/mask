using UnityEngine;

public class ChartSpawner : MonoBehaviour
{
    public ChartLoader loader;

    public LaneSpawner[] laneSpawners; // 4 spawners

    [Header("Timing")]
    public float noteTravelTime = 1.5f;

    private int nextIndex = 0;

    private void Update()
    {
        if (nextIndex >= loader.Notes.Count)
            return;

        float songTime = AudioManager.instance.GetMusicTime();

        while (nextIndex < loader.Notes.Count)
        {
            float noteTime = loader.Notes[nextIndex].timeDS / 10f;

            if (noteTime > songTime + noteTravelTime)
                break;

            NoteData note = loader.Notes[nextIndex];

            laneSpawners[note.lane].Spawn();

            nextIndex++;
        }
    }
}
