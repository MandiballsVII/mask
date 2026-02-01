using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowHoldDetector : MonoBehaviour
{
    public InputActionReference left;
    public InputActionReference right;
    public InputActionReference up;
    public InputActionReference down;

    public bool IsHolding(lookingDirection direction)
    {
        return direction switch
        {
            lookingDirection.Left => left.action.IsPressed(),
            lookingDirection.Right => right.action.IsPressed(),
            lookingDirection.Up => up.action.IsPressed(),
            lookingDirection.Down => down.action.IsPressed(),
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
