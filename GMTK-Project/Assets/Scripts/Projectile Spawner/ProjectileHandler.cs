using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileHandler : MonoBehaviour
{
    // fields

    [SerializeField] private float _projectileVelocity;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileLifetime = 20;


    // public methods

    public void SpawnProjectile()
    {
        var projectile = Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(_spawnPoint.forward * _projectileVelocity);
        Destroy(projectile, 20);
    }
}
