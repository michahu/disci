using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : CardComponent {

    private int DamageValue;

    public DamageComponent(int value)
    {
        this.DamageValue = value;
    } 

    public override void Action()
    {
        EnemyStats.enemyStatsInstance.Damage(DamageValue);
    }
}
