using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : CardComponent {

    private int HealValue;

    public HealComponent(int value)
    {
        this.HealValue = value;
    }

    public override void Action()
    {
        PlayerStats.playerStatsInstance.Heal(HealValue);
    }
}
