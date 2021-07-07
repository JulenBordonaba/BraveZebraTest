using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtendedButton : Button
{
    [SerializeField]
    private UnityEvent _onPointerEnter;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        _onPointerEnter?.Invoke();
    }
}
