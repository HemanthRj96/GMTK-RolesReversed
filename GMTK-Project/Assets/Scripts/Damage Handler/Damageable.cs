using UnityEngine;
using UnityEngine.Events;

public abstract class Damageable : MonoBehaviour, IDamage
{
    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private UnityEvent OnReceiveDamage;
    [SerializeField] private UnityEvent OnRemoveDamage;
    [SerializeField] private UnityEvent OnDead;

    public int HealthPoints { get; private set; }
    public int MaxHealthPoints { get => _maxHealthPoints; }


    public virtual void ApplyDamage(int hp = -1)
    {
        if (hp == -1)
        {
            HealthPoints = 0;
            OnReceiveDamage?.Invoke();
            OnDead?.Invoke();
        }
        else
        {
            HealthPoints = Mathf.Max(0, HealthPoints - hp);
            if (HealthPoints == 0)
            {
                OnReceiveDamage?.Invoke();
                OnDead?.Invoke();
            }
            else
                OnReceiveDamage?.Invoke();
        }
    }

    public virtual void RemoveDamage(int hp = -1)
    {
        if (hp == -1)
        {
            HealthPoints = MaxHealthPoints;
            OnRemoveDamage?.Invoke();
        }
        else
        {
            HealthPoints = Mathf.Min(MaxHealthPoints, HealthPoints + hp);
            OnRemoveDamage?.Invoke();
        }
    }


    // private methods

    private void Awake()
    {
        HealthPoints = _maxHealthPoints;
    }
}