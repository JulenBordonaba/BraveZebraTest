using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "Damage/DamageData", order = 1)]
public class DamageData : ScriptableObject
{
    #region Fields

    [SerializeField]
    private float _ammount;
    [SerializeField]
    private float _knockback;

    #endregion

    #region Properties

    public float ammount => _ammount;
    public float knockback => _knockback;

    #endregion
}
