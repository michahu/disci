using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    string EndGame = "You lost!";

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
    public override void Die()
    {
        base.Die();

        GameManager.instance.EndRound(EndGame);
    }
}
