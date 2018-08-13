using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int currentHealth; 

    public int armor;

    // alerting health and armor changes
    public event System.Action<int> OnHealthChanged;
    public event System.Action<int> OnArmorChanged;

    public void Damage (int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Armor (int ArmorValue) 
    {
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
