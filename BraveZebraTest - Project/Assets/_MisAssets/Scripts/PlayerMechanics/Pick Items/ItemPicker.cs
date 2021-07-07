using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemPicker : PlayerMechanic
{
    #region fields

    private PickerData _mechanicData;

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickeable pickeable = null;
        if((pickeable=collision.gameObject.GetComponent<IPickeable>())!=null)
        {
            pickeable.OnItemPicked(this);
            collision.gameObject.SetActive(false);
        }
    }

    #endregion

    #region Properties

    public override PlayerMechanicData mechanicData
    {
        get => _mechanicData;
        set => _mechanicData = (PickerData)value;
    }

    #endregion
}
