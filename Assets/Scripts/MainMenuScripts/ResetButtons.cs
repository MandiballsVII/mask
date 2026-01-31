using UnityEngine;

public class ResetButtons : MonoBehaviour
{
    public Vector3 buttonScale;
    public Transform buttonTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        buttonTransform.localScale = buttonScale;
    }
}
