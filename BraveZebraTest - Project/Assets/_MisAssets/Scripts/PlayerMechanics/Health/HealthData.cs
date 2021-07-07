using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Player/Mechanics/HealthData", order = 1)]
public class HealthData : PlayerMechanicData
{
    [SerializeField]
    private float _maxHealth;


    public float maxHealth => _maxHealth;

    public override Type playerMechanic => typeof(PlayerHealth);
}
