using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Color color;
    public float travelTime = 1.5f;
    public Transform hitPoint;

    public void Spawn()
    {
        GameObject note = Instantiate(notePrefab, transform.position, Quaternion.identity);

        note.GetComponent<SpriteRenderer>().color = color;
        note.layer = gameObject.layer;

        float distance = Vector2.Distance(transform.position, hitPoint.position);

        note.GetComponent<NoteMovement>().Initialize(distance, travelTime);
    }
}
