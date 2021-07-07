using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGravity
{
    #region fields

    private Rigidbody2D _rigidbody;
    private JumpData _jumpData;

    #endregion

    #region Constructors

    public JumpGravity(Rigidbody2D rigidbody, JumpData jumpData)
    {
        _rigidbody = rigidbody;
        _jumpData = jumpData;
    }

    #endregion

    #region Methods

    public void ApplyGravity(bool keyPressed)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y - GetGravity(keyPressed) * Time.fixedDeltaTime);
    }

    private float GetGravity(bool keyPressed)
    {
        if (_rigidbody.velocity.y < 0)
        {
            return _jumpData.fallGravity;
        }
        else
        {
            if (keyPressed)
            {
                return _jumpData.baseGravity;
            }
            else
            {
                return Mathf.Clamp(_jumpData.keyReleaseGravity, (-_rigidbody.velocity.y - 0.1f) / Time.fixedDeltaTime, (_rigidbody.velocity.y + 0.1f) / Time.fixedDeltaTime);
            }
        }
    }

    #endregion
}
