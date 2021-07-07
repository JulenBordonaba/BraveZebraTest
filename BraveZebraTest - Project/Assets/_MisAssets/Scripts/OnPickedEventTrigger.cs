using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnPickedEventTrigger : MonoBehaviour, IPickeable
{
    [SerializeField]
    private UnityEvent _onItemPicked = new UnityEvent();

    public void OnItemPicked(ItemPicker picker)
    {
        _onItemPicked.Invoke();
    }
}
