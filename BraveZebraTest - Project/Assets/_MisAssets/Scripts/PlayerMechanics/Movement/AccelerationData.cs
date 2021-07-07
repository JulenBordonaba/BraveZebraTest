using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccelerationData
{
    #region fields
    
    private float _maxVelocity;
    private float _accelerationTime;
    [SerializeField]
    private AnimationCurve _curve;

    #endregion

    #region Constructors

    public AccelerationData(float maxVelocity, float accelerationTime, AnimationCurve curve)
    {
        _maxVelocity = maxVelocity;
        _accelerationTime = accelerationTime;
        _curve = curve;
    }

    #endregion

    #region Properties

    public float accelerationTimeMultiplier
    {
        get
        {
            float curveTime = _curve[_curve.length - 1].time;

            float mul = (1f / curveTime) * _accelerationTime;

            return mul;
        }
    }

    public float accelerationVelocityMultiplier
    {
        get
        {
            float maxCurveVel = _curve[_curve.length - 1].value;

            float mul = (1f / maxCurveVel) * _maxVelocity;

            return mul;
        }
    }

    public float maxVelocity => _maxVelocity;

    public AnimationCurve curve => _curve;

    #endregion
}
