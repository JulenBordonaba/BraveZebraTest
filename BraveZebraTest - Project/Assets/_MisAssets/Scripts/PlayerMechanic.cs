using UnityEngine;

public abstract class PlayerMechanic : MonoBehaviour
{
    protected bool _allowed = true;

    public virtual void SetUp()
    {

    }

    public abstract PlayerMechanicData mechanicData { get; set; }
}
