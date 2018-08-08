using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    string EndGame = "You won!";

    public override void Die()
    {
        base.Die();

        // Add death animation??

        GameManager.instance.EndRound(EndGame);
    }
}
