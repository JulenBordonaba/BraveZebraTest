using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();

    public string triggerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            onTriggerEnter?.Invoke();
        }
    }
}
