using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpData", menuName = "Player/Mechanics/JumpData", order = 1)]
public class JumpData : PlayerMechanicData
{
    #region fields

    [SerializeField]
    protected JumpDataInputMode _dataType = JumpDataInputMode.VelocityGravity;
    [SerializeField]
    protected float _initialVelocity;
    [SerializeField]
    protected float _baseGravity;
    [SerializeField]
    protected float _keyReleaseGravity;
    [SerializeField]
    protected float _fallGravity;
    [SerializeField]
    protected float _maxHeight;
    [SerializeField]
    protected float _timeToMaxHeight;
    [SerializeField]
    protected float _coyoteTime;
    
    #endregion

    #region Properties

    public float initialVelicity
    {
        get => _initialVelocity;
        set => _initialVelocity = value;
        
    }

    public JumpDataInputMode dataType
    {
        get => _dataType;
        set => _dataType = value;
    }

    public float baseGravity
    {
        get => _baseGravity;
        set => _baseGravity = value;
    }

    public float keyReleaseGravity
    {
        get => _keyReleaseGravity;
        set => _keyReleaseGravity = value;
    }

    public float fallGravity
    {
        get => _fallGravity;
        set => _fallGravity = value;
    }

    public float maxHeight
    {
        get => _maxHeight;
        set => _maxHeight = value;
    }

    public float timeToMaxHeight
    {
        get => _timeToMaxHeight;
        set => _timeToMaxHeight = value;
    }

    public float coyoteTime
    {
        get => _coyoteTime;
        set => _coyoteTime = value;
    }

    public override Type playerMechanic => typeof(PlayerJump);



    #endregion

}
