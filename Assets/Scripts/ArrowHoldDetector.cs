using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowHoldDetector : MonoBehaviour
{
    public InputActionReference left;
    public InputActionReference right;
    public InputActionReference up;
    public InputActionReference down;

    public bool IsHolding(lokingDirection direction)
    {
        return direction switch
        {
            lokingDirection.Left => left.action.IsPressed(),
            lokingDirection.Right => right.action.IsPressed(),
            lokingDirection.Up => up.action.IsPressed(),
            lokingDirection.Down => down.action.IsPressed(),
            _ => false
        };
    }

    private void OnEnable()
    {
        left.action.Enable();
        right.action.Enable();
        up.action.Enable();
        down.action.Enable();
    }

    private void OnDisable()
    {
        left.action.Disable();
        right.action.Disable();
        up.action.Disable();
        down.action.Disable();
    }
}
