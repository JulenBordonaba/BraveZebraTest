using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region fields

    [SerializeField]
    private PlayerData _playerData;
    private List<PlayerMechanic> _mechanics;

    public Action<List<PlayerMechanic>> OnMechanicsInstalled;

    #endregion

    #region Methods

    private void Awake()
    {
        PlayerMechanicInstaller installer = new PlayerMechanicInstaller(this, _playerData.mechanics);
        _mechanics = installer.InstallMechanics();
        OnMechanicsInstalled?.Invoke(_mechanics);
    }
    
    #endregion

    #region Properties 

    public List<PlayerMechanic> mechanics => _mechanics;
    public PlayerData playerData => _playerData;
    
    #endregion
}
