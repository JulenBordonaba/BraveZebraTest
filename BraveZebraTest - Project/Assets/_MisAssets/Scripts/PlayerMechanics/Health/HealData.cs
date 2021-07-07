using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealData", menuName = "Damage/HealData", order = 1)]
public class HealData : ScriptableObject
{
    #region Fields

    [SerializeField]
    private float _ammount;

    #endregion

    #region Properties

    public float ammount => _ammount;

    #endregion
}
