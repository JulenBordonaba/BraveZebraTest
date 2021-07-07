using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    #region Fields

    [SerializeField]
    private List<PlayerMechanicData> _mechanics;

    #endregion

    #region Properties

    public List<PlayerMechanicData> mechanics => _mechanics;

    #endregion
}
