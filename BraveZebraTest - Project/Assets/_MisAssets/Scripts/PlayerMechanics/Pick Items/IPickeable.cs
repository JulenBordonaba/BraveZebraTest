using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickeable
{
    void OnItemPicked(ItemPicker picker);
}
