using UnityEngine;

public class ArrowData : MonoBehaviour
{
    public lookingDirection direction;
    private void OnDestroy()
    {
        ArrowInputState.ClearIfThisArrow(this);
    }
}