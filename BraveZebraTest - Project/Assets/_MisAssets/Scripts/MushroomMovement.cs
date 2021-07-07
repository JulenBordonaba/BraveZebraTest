using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MushroomMovement : MonoBehaviour
{

    [SerializeField]
    private GroundDetector _groundDetector;
    private bool _canChangeDirection = true;
    [SerializeField]
    private float _speed = 1;
    private float _dir = 1;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _baseScale;
    private Vector2 _velocity;
    private Animator _animator;

    private void Awake()
    {
        _baseScale = transform.localScale;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _velocity = new Vector2(_dir * _speed, _rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
        SetAnimator();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }

    private void SetAnimator()
    {
        _animator.SetFloat("velocity", Mathf.Abs(_velocity.x));
    }

    private void ChangeDirection()
    {
        if (_canChangeDirection)
        {
            if (!_groundDetector.isGrounded)
            {
                StartCoroutine(Rest(2f));
            }
        }
    }

    private IEnumerator Rest(float restTime)
    {
        _canChangeDirection = false;
        _dir *= -1;
        transform.localScale = new Vector3(_dir * _baseScale.x, _baseScale.y, _baseScale.z);
        _velocity = new Vector2(0, _rigidbody.velocity.y);

        yield return new WaitForSeconds(restTime);
        
        _velocity = new Vector2(_dir * _speed, _rigidbody.velocity.y);

        StartCoroutine(ChangeDirectionCooldown(0.1f));
    }

    private IEnumerator ChangeDirectionCooldown(float t)
    {
        yield return new WaitForSeconds(t);
        _canChangeDirection = true;
    }
}
