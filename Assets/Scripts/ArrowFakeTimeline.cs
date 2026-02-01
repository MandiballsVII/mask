using System.Collections;
using UnityEngine;

public class ArrowFakeTimeline : MonoBehaviour
{
    [System.Serializable]
    public class ArrowEntry
    {
        public ArrowLaneSpawner lane;
        public float startTime;
        public float endTime;
    }

    public ArrowEntry[] arrows;

    private float levelStartTime;

    void Start()
    {
        levelStartTime = Time.time;
        StartCoroutine(TimelineRoutine());
    }

    IEnumerator TimelineRoutine()
    {
        foreach (var entry in arrows)
        {
            float wait = entry.startTime - (Time.time - levelStartTime);
            if (wait > 0f)
                yield return new WaitForSeconds(wait);

            float travelDuration = entry.endTime - entry.startTime;
            entry.lane.SpawnArrow(travelDuration);
        }
    }
}
