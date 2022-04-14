using UnityEngine.Events;
using UnityEngine;

public class EHDamageableComponent : EHActorComponent
{
    public UnityAction OnActorDied;
    public int CurrentHealth;

    public void TakeDamage(FAttackData AttackData)
    {
        CurrentHealth -= AttackData.DamageAmount;
        if (CurrentHealth <= 0)
        {
            ActorDied();
        }
    }
    
    // This function should only be called once upon the actors health reaching 0 after they have
    // taken damage
    protected void ActorDied()
    {
        CurrentHealth = 0;
        OnActorDied?.Invoke();
    }
}
