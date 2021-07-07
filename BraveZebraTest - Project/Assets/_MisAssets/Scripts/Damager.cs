using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Damager : MonoBehaviour
{
    #region fields

    [SerializeField]
    private DamageData _damageData;
    [SerializeField]
    private bool _isTrigger;
    private Rigidbody2D _rigidbody;

    #endregion

    #region Methods

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isTrigger) return;
        IDamageable damageable = null;
        if ((damageable = collision.gameObject.GetComponent<IDamageable>()) != null)
        {
            damageable.TakeDamage(_damageData, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isTrigger) return;
        IDamageable damageable = null;
        if((damageable=collision.gameObject.GetComponent<IDamageable>())!= null)
        {
            damageable.TakeDamage(_damageData,gameObject);
        }
    }

    #endregion
}
