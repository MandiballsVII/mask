using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowSequenceManager : MonoBehaviour
{
    [Header("Arrow Lanes (orden importa)")]
    public List<ArrowLaneSpawner> arrowLanes;

    [Header("Timing")]
    public float travelDuration = 2f;
    public float overlapTime = 0.2f;

    private int currentIndex;

    void Start()
    {
        StartCoroutine(ArrowRoutine());
    }

    IEnumerator ArrowRoutine()
    {
        while (true)
        {
            ArrowLaneSpawner lane = arrowLanes[currentIndex];
            lane.SpawnArrow(travelDuration);

            currentIndex = (currentIndex + 1) % arrowLanes.Count;

            float waitTime = Mathf.Max(0f, travelDuration - overlapTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
