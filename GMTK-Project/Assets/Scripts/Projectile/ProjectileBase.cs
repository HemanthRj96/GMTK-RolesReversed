using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBase : MonoBehaviour
{
    // fields

    [SerializeField] private string _bounceSurfaceTag;

    bool _hasHit = false;


    // protected methods

    protected virtual void OnHit(Collision collision) { }


    // private methods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(gameObject))
            return;
        if (collision.collider.CompareTag(_bounceSurfaceTag))
            return;

        if (!_hasHit)
        {
            _hasHit = true;
            OnHit(collision);
        }
    }
}
