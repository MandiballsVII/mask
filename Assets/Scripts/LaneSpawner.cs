using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Color color;

    private float timer;

    public float timeGap;

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > timeGap)
        {
            Spawn();
            timer = 0f;
        }
    }

    public void Spawn()
    {
        GameObject note = Instantiate(notePrefab, transform.position, Quaternion.identity);

        // Color
        note.GetComponent<SpriteRenderer>().color = color;

        note.layer = gameObject.layer;
        timeGap = Random.Range(0, 5);
    }

    
}
