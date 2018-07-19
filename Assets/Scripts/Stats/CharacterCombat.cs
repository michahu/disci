using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    CharacterStats myStats;
    bool start;

    void Start ()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack (GameObject enemy)
    {
        start = GameManager.inCombat;
        if (start == true)
        {
            CharacterStats targetStats = enemy.GetComponent<CharacterStats>();
            targetStats.TakeDamage(myStats.damage.GetValue());
            start = false;
        }
        // trigger enemy attack (probably from GameManager) or another event 
        // action linked to the character clicking attack
    }
}
