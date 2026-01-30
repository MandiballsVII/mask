using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject notePrefab;
    public BoxCollider2D laneCollider;

    [Header("Spawn")]
    public float spawnInterval = 1f;

    private float timer;

    void Reset()
    {
        laneCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNote();
            timer = 0f;
        }
    }

    void SpawnNote()
    {
        Bounds bounds = laneCollider.bounds;

        float spawnX = bounds.max.x;
        float spawnY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        Instantiate(notePrefab, spawnPosition, Quaternion.identity);
    }
}

