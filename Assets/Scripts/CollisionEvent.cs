using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : CollisionChecker
{
    [SerializeField] public UnityEvent OnTouching;
    [SerializeField] public UnityEvent OnLeaving;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the colliding object is on a layer included in the ground mask.
        if (IsTargetLayer(other.gameObject.layer))
        {
            IsTouching = true;
            OnTouching.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Stop considering the ground touched once the object leaves the ground layer.
        if (IsTargetLayer(other.gameObject.layer))
        {
            IsTouching = false;
            OnLeaving.Invoke();
        }
    }
}