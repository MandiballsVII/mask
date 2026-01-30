using UnityEngine;

public class NoteCleanup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            Destroy(other.gameObject);
        }
    }
}