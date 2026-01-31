using UnityEngine;
using System;

public class NotifyOnDestroy : MonoBehaviour
{
    private Action onDestroyed;

    public void Init(Action callback)
    {
        onDestroyed = callback;
    }

    private void OnDestroy()
    {
        onDestroyed?.Invoke();
    }
}
