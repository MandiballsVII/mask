using UnityEngine;

public class ResetButtons : MonoBehaviour
{
    public Vector3 buttonScale;
    public RectTransform buttonTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        buttonTransform.localScale = buttonScale;
    }
}
