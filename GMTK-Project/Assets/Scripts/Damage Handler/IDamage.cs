using UnityEngine;
using UnityEngine.Events;

public interface IDamage
{
    int HealthPoints { get; }
    int MaxHealthPoints { get; }


    // -1 means full damage
    void ApplyDamage(int hp = -1);
    // -1 means full heal
    void RemoveDamage(int hp = -1);
}