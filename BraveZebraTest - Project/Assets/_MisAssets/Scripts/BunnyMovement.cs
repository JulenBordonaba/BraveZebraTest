using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GroundDetector _groundDetector;
    private bool _canChangeDirection = true;
    private bool _canRace = true;
    [SerializeField]
    private float _speed = 1.2f;
    private float _dir;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _baseScale;
    private Vector2 _velocity;
    private Animator _animator;
    private bool _groundedLastFrame;
    private float _gravity = 9.8f;

    private void Awake()
    {
        _baseScale = transform.localScale;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _velocity = new Vector2(_dir * _speed, _rigidbody.velocity.y);
        _groundedLastFrame = false;

        float g = Mathf.Abs(Physics2D.gravity.y);

        _rigidbody.gravityScale = _gravity / g;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_groundedLastFrame)
        {
            if (_groundDetector.isGrounded)
            {
                StartCoroutine(Race());
            }
        }
        SetAnimator();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_velocity.x, _rigidbody.velocity.y);
    }

    private void SetAnimator()
    {
        _animator.SetFloat("velX", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat("velY", _rigidbody.velocity.y);
        _animator.SetBool("isGrounded", _groundDetector.isGrounded);
    }

    private IEnumerator Race()
    {
        if (!_canRace) yield break;
        _canRace = false;
        print("StartRace");
        ChangeDirection();
        //SetVelocity(0);
        //yield return new WaitForSeconds(1f);

        SetVelocity(_speed);

        yield return new WaitForSeconds(2f);
        Jump();
        _canRace=true;
    }

    private void Jump()
    {
        float h = Mathf.Max(0, _player.transform.position.y - transform.position.y);
        h += 2;

        print(h);

        float t = 1f;

        _gravity = (2 * h) / Mathf.Pow(t, 2);

        float g = Mathf.Abs(Physics2D.gravity.y);

        _rigidbody.gravityScale = _gravity / g;

        float v = Mathf.Sqrt(2 * _gravity * h);

        print(v);

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, v);
    }
    private void SetVelocity(float velocity)
    {
        _velocity.x = velocity * direction;
    }

    private void ChangeDirection()
    {
        if (_canChangeDirection)
        {
            if (_groundDetector.isGrounded)
            {
                _dir = direction;
                transform.localScale = new Vector3(_dir * _baseScale.x, _baseScale.y, _baseScale.z);
                StartCoroutine(ChangeDirectionCooldown(0.1f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
        {
            ChangeDirection();
        }
    }
    private IEnumerator ChangeDirectionCooldown(float t)
    {
        _canChangeDirection = false;
        yield return new WaitForSeconds(t);
        _canChangeDirection = true;
    }

    private float direction
    {
        get
        {
            Vector3 aux = _player.transform.position - transform.position;
            aux.y = 0;
            aux.z = 0;
            aux.Normalize();

            return aux.x;
        }
    }
}
