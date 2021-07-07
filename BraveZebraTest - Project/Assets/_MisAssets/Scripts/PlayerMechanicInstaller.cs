using System.Collections.Generic;

public class PlayerMechanicInstaller
{
    private Player _player;
    private List<PlayerMechanicData> _mechanics;

    public PlayerMechanicInstaller(Player player, List<PlayerMechanicData> mechanics)
    {
        _player = player;
        _mechanics = mechanics;
    }

    public List<PlayerMechanic> InstallMechanics()
    {
        List<PlayerMechanic> playerMechanics = new List<PlayerMechanic>();

        foreach (PlayerMechanicData mechanic in _mechanics)
        {
            playerMechanics.Add(SetUpMechanic(mechanic));
        }

        return playerMechanics;
    }

    private PlayerMechanic SetUpMechanic(PlayerMechanicData mechanic)
    {
        PlayerMechanic playerMechanic = (PlayerMechanic)_player.gameObject.AddComponent(mechanic.playerMechanic);
        playerMechanic.mechanicData = mechanic;
        playerMechanic.SetUp();
        return playerMechanic;
    }
}
