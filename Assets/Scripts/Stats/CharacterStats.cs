using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour {

    public int currentHealth; 

    public int armor;

    // alerting health and armor changes
    public event System.Action<int> OnHealthChanged;
    public event System.Action<int> OnArmorChanged;

    public void Damage (int damage)
    {
        // reduce damage
        int unblockedDamage = damage - armor;
        unblockedDamage = Mathf.Clamp(unblockedDamage, 0, int.MaxValue);

        // reduce armor
        Armor(-damage);

        currentHealth -= unblockedDamage;
        Debug.Log(transform.name + " takes " + unblockedDamage + " damage.");

        if (OnHealthChanged != null && currentHealth >= 0)
        {
            OnHealthChanged(currentHealth);
        }

        else OnHealthChanged(0);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Armor (int ArmorValue) 
    {
        ArmorValue = Math.Max(-armor, ArmorValue);
        armor += ArmorValue;
        Debug.Log(transform.name + " gained " + armor + " armor.");

        if (OnArmorChanged != null)
        {
            OnArmorChanged(armor);
        }
    }

    public void Heal (int HealValue) 
    {
        currentHealth += HealValue;
        Debug.Log(transform.name + " gained" + HealValue + " health.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth);
        }
    }

    public virtual void Die ()
    {
        Debug.Log(transform.name + " died.");
    }
}
