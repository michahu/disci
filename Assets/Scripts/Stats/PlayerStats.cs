using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats {
    
    public static PlayerStats playerStatsInstance;

    void Awake()
    {
        if (playerStatsInstance != null && playerStatsInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerStatsInstance = this;
        }
    }

    public Animator animator;

    string EndGame = "You lost!";

    public int maxHealth = 10;
    public int mana = 5;

    public Text healthText;
    public Text armorText;
    public Text manaText;

    private void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;

        armor = 0;

        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();
        manaText.text = mana.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthTextChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorTextChanged;
    }

    
    public override void Die()
    {
        base.Die();

        animator.SetTrigger("Die");
        GameManager.instance.EndRound(EndGame);
    }

    void OnHealthTextChanged(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    void OnArmorTextChanged(int newArmor)
    {
        armorText.text = newArmor.ToString();
    }

    public void Mana(int cost)
    {
        mana -= cost;
        manaText.text = mana.ToString();
    }

    // shitty fix
    public void ResetMana()
    {
        mana = 5;
        manaText.text = mana.ToString();
    }
}
