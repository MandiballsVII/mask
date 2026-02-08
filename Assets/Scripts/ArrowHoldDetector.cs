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
        if (PauseManager.instance.IsPaused)
            return false;

        bool l = left.action.IsPressed();
        bool r = right.action.IsPressed();
        bool u = up.action.IsPressed();
        bool d = down.action.IsPressed();

        int pressedCount = 0;
        if (l) pressedCount++;
        if (r) pressedCount++;
        if (u) pressedCount++;
        if (d) pressedCount++;

        // Debe haber SOLO una pulsada
        if (pressedCount != 1)
            return false;

        return direction switch
        {
            lookingDirection.Left => l,
            lookingDirection.Right => r,
            lookingDirection.Up => u,
            lookingDirection.Down => d,
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
