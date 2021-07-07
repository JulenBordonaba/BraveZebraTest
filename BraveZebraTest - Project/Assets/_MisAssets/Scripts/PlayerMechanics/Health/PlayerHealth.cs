using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : PlayerMechanic, IDamageable
{
    #region fields
    
    private HealthData _mechanicData;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _currentHealth;

    public Action<float> OnHealthChanged;

    #endregion

    #region Methods

    public override void SetUp()
    {
        base.SetUp();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentHealth = _mechanicData.maxHealth;
        _currentHealth -= 1;
    }

    public void Heal(HealData healData, GameObject healer)
    {
        _currentHealth += healData.ammount;
        _currentHealth = Mathf.Clamp(_currentHealth, float.MinValue, _mechanicData.maxHealth);

        OnHealthChanged.Invoke(_currentHealth);
    }

    public void TakeDamage(DamageData damageData, GameObject attacker)
    {
        _currentHealth -= damageData.ammount;

        OnHealthChanged.Invoke(_currentHealth);

        ApplyKnockback(damageData, attacker);

        if(damageData.ammount>0)
        {
            _animator.SetTrigger("hit");
        }

        if(_currentHealth<=0)
        {
            Die();
        }
    }

    private void ApplyKnockback(DamageData damageData, GameObject attacker)
    {
        Vector2 dir = transform.position - attacker.transform.position;
        dir.Normalize();

        Vector2 knockback = dir * damageData.knockback;

        _rigidbody.velocity += knockback;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    #region Properties

    public float currentHealth => _currentHealth;
    
    public override PlayerMechanicData mechanicData
    {
        get => _mechanicData;
        set => _mechanicData = (HealthData)value;
    }

    #endregion
}
