using UnityEngine;

public class ArrowVisualFeedback : MonoBehaviour
{
    [Header("Materials")]
    public Material normalMaterial;
    public Material activeMaterial; // emisivo

    private SpriteRenderer sr;
    private ArrowData arrowData;
    private ArrowHoldDetector holdDetector;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // Lo buscamos en escena (uno global)
        holdDetector = FindObjectOfType<ArrowHoldDetector>();
        print(holdDetector.gameObject.name);
        sr.material = normalMaterial;
    }
    private void Start()
    {
        arrowData = GetComponent<ArrowData>();
    }

    void Update()
    {
        if (arrowData == null || holdDetector == null)
            return;

        // Solo la arrow activa puede reaccionar
        if (ArrowInputState.activeArrow != arrowData)
        {
            sr.material = normalMaterial;
            return;
        }

        bool isHolding = holdDetector.IsHolding(arrowData.direction);
        sr.material = isHolding ? activeMaterial : normalMaterial;
    }

}
