using System;
using UnityEngine;


public static class GlobalEvents
{
    public static event Action OnPlayerProjectileFire;
    public static event Action OnPlayerProjectileEnd;
    public static event Action OnEnemyProjectileFire;
    public static event Action OnEnemyProjectileEnd;


    public static void Invoke_PlayerProjectileFire()
    {
        OnPlayerProjectileFire?.Invoke();
    }

    public static void Invoke_PlayerProjectileEnd()
    {
        OnPlayerProjectileEnd?.Invoke();
    }

    public static void Invoke_EnemyProjectileFire()
    {
        OnEnemyProjectileFire?.Invoke();
    }

    public static void Invoke_EnemyProjectileEnd()
    {
        OnEnemyProjectileEnd?.Invoke();
    }
}