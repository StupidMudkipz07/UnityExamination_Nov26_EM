using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
     public bool IsTouching;

    [SerializeField] protected LayerMask targetLayer;
    
    protected bool IsTargetLayer(int layer)
    {
        // Bitwise check: is the object's layer part of the ground mask?5
        return (targetLayer.value & (1 << layer)) != 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the colliding object is on a layer included in the ground mask.
        if (IsTargetLayer(other.gameObject.layer))
        {
            IsTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Stop considering the ground touched once the object leaves the ground layer.
        if (IsTargetLayer(other.gameObject.layer))
        {
            IsTouching = false;
        }
    }


}