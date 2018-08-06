using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject target;
    public Text health;
    public Text armor;

    public int MyCurrentHealth;
    public int MyCurrentArmor;
    int MyMaxHealth;

    int EnemyHealth;
    int EnemyArmor;

	// Use this for initialization
	void Start () {

        MyCurrentArmor = 0;
        MyMaxHealth = 10;
        MyCurrentHealth = Mathf.Clamp(MyCurrentHealth, 0, MyMaxHealth);
        MyCurrentArmor = Mathf.Clamp(MyCurrentArmor, 0, int.MaxValue);

        EnemyHealth = target.GetComponentInChildren<Health>().MyCurrentHealth;
        EnemyArmor = target.GetComponentInChildren<Health>().MyCurrentArmor;

        health.text = MyMaxHealth.ToString();
        armor.text = MyCurrentArmor.ToString();
	}
	
	// Update is called once per frame
	public void UpdateStats () {

        health.text = MyCurrentHealth.ToString();
        armor.text = MyCurrentArmor.ToString();
	}

    public void Attack (int DamageValue) {

        DamageValue = Mathf.Clamp(DamageValue, 0, int.MaxValue);
        EnemyHealth = EnemyHealth + EnemyArmor - DamageValue;
        UpdateStats();

        if (EnemyHealth <= 0)
        {
            Die();

        }
    }

    public void Armor (int ArmorValue) {
        
        MyCurrentArmor += ArmorValue;
        UpdateStats();
    }

    public void Heal (int HealValue) {

        MyCurrentHealth += HealValue;
        UpdateStats();
    }

    public virtual void Die() {
        Debug.Log("Enemy died.");
    }

}
