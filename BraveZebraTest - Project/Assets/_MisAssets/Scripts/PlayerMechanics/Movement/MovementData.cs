using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "MovementData", menuName = "Player/Mechanics/MovementData", order = 1)]
public class MovementData : PlayerMechanicData
{
    #region Fields

    [SerializeField]
    private float _maxVelocity;
    [SerializeField]
    private float _accelerationTime;
    [SerializeField]
    private float _decelerationTime;
    [SerializeField]
    private AnimationCurve _accelerationCurve;
    [SerializeField]
    private AnimationCurve _decelerationCurve;

    #endregion

    #region Properties

    public float maxVelocity => _maxVelocity;
    
    public AccelerationData accelerationdata => new AccelerationData(_maxVelocity, _accelerationTime, _accelerationCurve);

    public AccelerationData decelerationData => new AccelerationData(_maxVelocity, _decelerationTime, _decelerationCurve);

    public override Type playerMechanic => typeof(PlayerMovement);

    #endregion

}
