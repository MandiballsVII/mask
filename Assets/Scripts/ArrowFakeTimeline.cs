using System.Collections;
using UnityEngine;

public class ArrowFakeTimeline : MonoBehaviour
{
    [Header("Spawners por dirección")]
    public ArrowLaneSpawner leftSpawner;   // Felicidad
    public ArrowLaneSpawner downSpawner;   // Tristeza
    public ArrowLaneSpawner upSpawner;     // Ira
    public ArrowLaneSpawner rightSpawner;  // Miedo

    void Start()
    {
        StartCoroutine(TimelineRoutine());
    }

    IEnumerator TimelineRoutine()
    {
        float levelStartTime = Time.time;

        // ---------- 1 IZQUIERDA (Felicidad) ----------
        yield return WaitUntilTime(levelStartTime, 0f);
        leftSpawner.SpawnArrow(travelDuration: 36f);

        // ---------- 2 ABAJO (Tristeza) ----------
        yield return WaitUntilTime(levelStartTime, 38f);
        downSpawner.SpawnArrow(travelDuration: 22f); // 01:00 - 00:38

        // ---------- 3 ARRIBA (Ira) ----------
        yield return WaitUntilTime(levelStartTime, 62f);
        upSpawner.SpawnArrow(travelDuration: 40f); // 01:42 - 01:02

        // ---------- 4 DERECHA (Miedo) ----------
        yield return WaitUntilTime(levelStartTime, 104f);
        rightSpawner.SpawnArrow(travelDuration: 40f); // 02:24 - 01:44
    }

    IEnumerator WaitUntilTime(float startTime, float targetSeconds)
    {
        while (Time.time - startTime < targetSeconds)
            yield return null;
    }
}
