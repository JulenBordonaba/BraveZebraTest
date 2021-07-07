using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickerData", menuName = "Player/Mechanics/Pickerdata", order = 1)]
public class PickerData : PlayerMechanicData
{
    public override Type playerMechanic => typeof(ItemPicker);
}
