using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void Heal(HealData healData, GameObject healer);
    void TakeDamage(DamageData damageData, GameObject attacker);
}
