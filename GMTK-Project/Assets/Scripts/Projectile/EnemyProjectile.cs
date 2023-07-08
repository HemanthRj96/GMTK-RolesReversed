using System.Collections;
using UnityEngine;


public class EnemyProjectile : ProjectileBase
{
    protected override void OnHit(Collision collision)
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        if (collision.collider.TryGetComponent<Damageable>(out Damageable dmg))
            dmg.ApplyDamage();

        Destroy(gameObject);
        GlobalEvents.Invoke_EnemyProjectileEnd();
    }
}
