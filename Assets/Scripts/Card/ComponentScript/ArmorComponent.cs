using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorComponent : CardComponent {

    private int ArmorValue;

    public ArmorComponent(int value)
    {
        this.ArmorValue = value;
    }

    public override void Action()
    {
        PlayerStats.playerStatsInstance.Armor(ArmorValue);
    }
}
