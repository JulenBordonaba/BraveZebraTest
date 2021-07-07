using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHUD : MonoBehaviour
{
    #region fields

    [SerializeField]
    private GameObject _heartPrefab;
    [SerializeField]
    private Player _player;

    private PlayerHealth _playerhealth;
    private List<HUDHeart> _hearts;

    #endregion

    #region Methods

    private void Awake()
    {
        _hearts = new List<HUDHeart>();
        _player.OnMechanicsInstalled += OnPlayerMechanicsInstalled;
    }

    private void OnPlayerMechanicsInstalled(List<PlayerMechanic> mechanics)
    {
        if (SetPlayerHealth(mechanics))
        {
            _playerhealth.OnHealthChanged += OnHealthChanged;
            SetHearts();
            OnHealthChanged(_playerhealth.currentHealth);
        }

    }

    private bool SetPlayerHealth(List<PlayerMechanic> mechanics)
    {
        foreach (PlayerMechanic mechanic in mechanics)
        {
            if (mechanic.GetType() == typeof(PlayerHealth))
            {
                _playerhealth = (PlayerHealth)mechanic;
                return true;
            }
        }
        return false;
    }

    private void OnHealthChanged(float newHealth)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].SetFilled(_hearts[i].index < newHealth);
        }
    }

    private void SetHearts()
    {
        for (int i = 0; i < ((HealthData)_playerhealth.mechanicData).maxHealth; i++)
        {
            HUDHeart heart = Instantiate(_heartPrefab, transform).GetComponent<HUDHeart>();
            heart.index = i;
            heart.transform.SetAsLastSibling();
            _hearts.Add(heart);
        }
    }

    #endregion
}
