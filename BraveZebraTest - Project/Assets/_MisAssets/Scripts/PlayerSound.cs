using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //Me ha faltado tiempo para hacer este script bien

    [SerializeField]
    private AudioSource _jumpSound;

    private PlayerInputActions _playerInputActions;

    private GroundDetector _groundDetector;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Jump.started += (x) => { JumpSound(); } ; 
        _playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Jump.Disable();
    }

    private void JumpSound()
    {
        if(groundDetector!=null)
        {
            if(groundDetector.isGrounded)
            {
                if(_jumpSound.isPlaying)
                {
                    _jumpSound.Stop();
                }
                _jumpSound.Play();
            }
        }
    }

    private GroundDetector groundDetector
    {
        get
        {
            if(_groundDetector==null)
            {
                _groundDetector = GetComponent<GroundDetector>();
            }
            return _groundDetector;
        }
    }
}
