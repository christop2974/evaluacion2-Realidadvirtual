using UnityEngine;

/// <summary>Base class for objects activated by looking at them.</summary>
public abstract class GazeTarget : MonoBehaviour
{
    public virtual void OnGazeEnter() { }
    public virtual void OnGazeExit() { }
    public abstract void Activate();
}
