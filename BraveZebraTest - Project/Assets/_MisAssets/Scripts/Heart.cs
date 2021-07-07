using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, IPickeable
{
    #region fields

    [SerializeField]
    private HealData _healData;
    [SerializeField]
    private AudioSource _onPickSound;

    #endregion


    public void OnItemPicked(ItemPicker picker)
    {
        IDamageable damageable = null;

        if((damageable = picker.GetComponent<IDamageable>()) != null)
        {
            _onPickSound.transform.SetParent(null);
            _onPickSound.Play();
            Destroy(_onPickSound.gameObject, _onPickSound.clip.length);
            damageable.Heal(_healData, null);
        }
    }
    
}
