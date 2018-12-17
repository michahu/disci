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
        PlayerStats.playerStatsInstance.animator.SetTrigger("Attack");
        if (EnemyStats.enemyStatsInstance.dodge != 0) {
            float x = EnemyStats.enemyStatsInstance.dodge / 100;
            if (Random.value > x) EnemyStats.enemyStatsInstance.Damage(DamageValue);
            else Debug.Log("Dodged the attack.");
        }
        else EnemyStats.enemyStatsInstance.Damage(DamageValue);
        EnemyStats.enemyStatsInstance.animator.SetTrigger("On Hit");
    }
}
