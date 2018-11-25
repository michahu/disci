using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonComponent : CardComponent
{

    private int DamageValue;
    private int TurnCounter = 2;

    public PoisonComponent(int value)
    {
        this.DamageValue = value;
 
    }

    public override void Action()
    {
        PlayerStats.playerStatsInstance.animator.SetTrigger("Attack");
        EnemyStats.enemyStatsInstance.poisoned = true;
        EnemyStats.enemyStatsInstance.Damage(DamageValue);
        EnemyStats.enemyStatsInstance.animator.SetTrigger("On Hit");
        TurnCounter--;
        if (TurnCounter <= 0) EnemyStats.enemyStatsInstance.poisoned = false;
    }
}
