using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : PlayerMechanic
{
    #region Fields

    private PlayerInputActions _playerInputActions;
    private InputAction _playerMovement;
    private MovementData _mechanicData;

    private float _lastDirection=1;
    
    //Acceleration Data
    private float curveTime = 0;
    private AccelerationData _currentAcceleration;

    //Components
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    #endregion

    #region Methods

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInputActions = new PlayerInputActions();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        SetAnimatorParameters();
    }

    private void FixedUpdate()
    {
        if (!_allowed) return;
        SetDirection();
        CheckMovement();
        Accelerate(_currentAcceleration);
    }

    private void CheckMovement()
    {
        if(anyMovementKeys)
        {
            StartAccelerating();
        }
        else
        {
            StartDecelerating();
        }
    }

    private void SetAnimatorParameters()
    {
        _animator.SetFloat("velX", Mathf.Abs(_rigidbody.velocity.x));
    }

    private void StartDecelerating()
    {
        float currentVelocity = Mathf.Abs(_rigidbody.velocity.x);
        _currentAcceleration = _mechanicData.decelerationData;
        curveTime = _currentAcceleration.curve.GetTimeFromValue(currentVelocity);
    }

    private void StartAccelerating()
    {
        float currentVelocity = Mathf.Abs(_rigidbody.velocity.x);
        _currentAcceleration = _mechanicData.accelerationdata;
        curveTime = _currentAcceleration.curve.GetTimeFromValue(currentVelocity);
    }

    private void Accelerate(AccelerationData accelerationData)
    {
        curveTime += Time.fixedDeltaTime;

        float newVelX = 0;
        newVelX = accelerationData.curve.Evaluate(curveTime);
        
        Vector2 newVelocity = new Vector2(newVelX * _lastDirection, _rigidbody.velocity.y);

        _rigidbody.velocity = newVelocity;
    }

    private void SetDirection()
    {
        if (lateralInput == 0) return;

        _lastDirection = lateralInput;
        _spriteRenderer.flipX = !(lateralInput>0);
    }

    private void OnEnable()
    {
        _playerMovement = _playerInputActions.Player.LateralMovement;
        _playerMovement.Enable();
    }
    
    private void OnDisable()
    {
        _playerMovement.Disable();
    }

    #endregion

    #region Properties

    private float lateralInput => _playerMovement.ReadValue<float>();

    private bool anyMovementKeys => lateralInput != 0;

    public override PlayerMechanicData mechanicData
    {
        get => _mechanicData;
        set => _mechanicData = (MovementData)value;
    }

    #endregion
}
