using UnityEngine;

public class NoteTarget : MonoBehaviour
{
    public static NoteTarget Instance;

    private void Awake()
    {
        Instance = this;
    }
}
