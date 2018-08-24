using UnityEngine;

public class ManaComponent : CardComponent {

    private int ManaValue;

    public ManaComponent(int value)
    {
        this.ManaValue = value;
    }

    public override void Action()
    {
        PlayerStats.playerStatsInstance.IncreaseMana(ManaValue);
        
    }
}
