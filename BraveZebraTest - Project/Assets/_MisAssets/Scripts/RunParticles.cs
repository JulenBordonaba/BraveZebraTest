using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunParticles : MonoBehaviour
{
    //Me ha faltado tiempo para hacer este script bien

    [SerializeField]
    private ParticleSystem _runParticles;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;

    private float _scale;


    private void Awake()
    {
        _scale = _runParticles.transform.localScale.x;
    }

    private void Update()
    {
        SetActive();
        SetDirection();
    }

    private void SetDirection()
    {
        if (_rigidbody.velocity.x == 0) return;
        float dir = 0;
        dir = _rigidbody.velocity.x > 0 ? 1 : -1;
        Vector3 auxScale = _runParticles.transform.localScale;
        _runParticles.transform.localScale = new Vector3(_scale * dir, auxScale.y, auxScale.z);

    }

    private void SetActive()
    {
        bool shouldPlay = false;
        if (groundDetector != null)
        {
            if (groundDetector.isGrounded)
            {
                shouldPlay = true;
            }
        }
        if (shouldPlay)
        {
            if (!_runParticles.isPlaying)
            {
                _runParticles.Play();
            }
        }
        else
        {
            if (!_runParticles.isStopped)
            {
                _runParticles.Stop();
            }
        }
    }

    private GroundDetector groundDetector
    {
        get
        {
            if (_groundDetector == null)
            {
                _groundDetector = GetComponentInParent<GroundDetector>();
            }
            return _groundDetector;
        }
    }
}
