using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    private void Update()
    {
        
    }
    public void Spawn()
    {
        Instantiate(notePrefab, transform.position, Quaternion.identity);
    }
}

