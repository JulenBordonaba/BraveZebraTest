using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : PlayerMechanic
{
    #region Fields

    private PlayerInputActions _playerInputActions;
    private JumpData _mechanicData;

    private float? _lastGroundedTime;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private GroundDetector _groundDetector;
    private JumpGravity _jumpGravity;
    private bool _keyPressed;

    #endregion

    #region Methods

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInputActions = new PlayerInputActions();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    public override void SetUp()
    {
        base.SetUp();
        if ((_groundDetector = gameObject.GetComponent<GroundDetector>()) == null)
        {
            _groundDetector = gameObject.AddComponent<GroundDetector>();
        }
        _jumpGravity = new JumpGravity(_rigidbody, _mechanicData);
    }

    private void Update()
    {
        if (_groundDetector.isGrounded)
        {
            _lastGroundedTime = Time.time;
        }
        SetAnimatorParameters();
    }

    private void SetAnimatorParameters()
    {
        _animator.SetBool("isGrounded", _groundDetector.isGrounded);
        _animator.SetFloat("velY", _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        if (!_groundDetector.isGrounded)
        {
            _jumpGravity.ApplyGravity(_keyPressed);
        }
    }

    private void CheckJump(InputAction.CallbackContext obj)
    {
        if (Time.time - _lastGroundedTime < _mechanicData.coyoteTime)
        {
            DoJump();
            _lastGroundedTime = 0;
        }
    }

    private void DoJump()
    {
        SetVelocity(_mechanicData.initialVelicity);
    }

    private void SetVelocity(float velocity)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, velocity);
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Jump.performed += CheckJump;

        _playerInputActions.Player.Jump.started += (x) => _keyPressed = true;
        _playerInputActions.Player.Jump.canceled += (x) => _keyPressed = false;
        _playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Jump.Disable();
    }

    #endregion

    #region Properties

    public override PlayerMechanicData mechanicData
    {
        get => _mechanicData;
        set => _mechanicData = (JumpData)value;
    }

    #endregion
}
