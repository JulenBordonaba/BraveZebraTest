using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundDetector : MonoBehaviour
{
    #region fields
    
    private List<Collider2D> _touchingColliders;
    private Rigidbody2D _rigidbody;

    #endregion

    #region Methods

    private void Awake()
    {
        _touchingColliders = new List<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_touchingColliders.Contains(collision))
        {
            if (collision.CompareTag("Ground"))
            {
                _touchingColliders.Add(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_touchingColliders.Contains(collision))
        {
            _touchingColliders.Remove(collision);
        }
    }

    #endregion

    #region Properties

    public bool isGrounded => _touchingColliders.Count>0;

    #endregion
}
