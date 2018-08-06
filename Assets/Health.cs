using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    
    public Text health;
    public Text armor;

    int CurrentHealth;
    int MaxHealth;
    int CurrentArmor;

	// Use this for initialization
	void Start () {

        CurrentArmor = 0;
        MaxHealth = 10;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        health.text = MaxHealth.ToString();
        armor.text = CurrentArmor.ToString();
	}
	
	// Update is called once per frame
	public void UpdateStats () {

        health.text = CurrentHealth.ToString();
        armor.text = CurrentArmor.ToString();
	}

    public void Attack (int DamageValue) {

        DamageValue = Mathf.Clamp(DamageValue, 0, int.MaxValue);
        CurrentHealth -= DamageValue;
        UpdateStats();

        if (CurrentArmor <= 0)
        {
            Die();

        }
    }

    public void Armor (int ArmorValue) {
        
        CurrentArmor += ArmorValue;
        if (CurrentArmor < 0) CurrentArmor = 0;
        UpdateStats();
    }

    public void Heal (int HealValue) {

        CurrentHealth += HealValue;
        UpdateStats();
    }

    public virtual void Die() {
        Debug.Log("Player died.");
    }

}
