using System.Collections;
using System.Collections.Generic;
using System;
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

    public event Action<int> OnManaChanged;

    public int maxHealth;
    public int maxMana;
    public int currentMana;

    public Text healthText;
    public Text armorText;
    public Text manaText;

    private void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;
        currentMana = maxMana;

        armor = 0;

        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();
        manaText.text = currentMana.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthTextChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorTextChanged;
        OnManaChanged += OnManaTextChanged;
    }

    
    public override void Die()
    {
        base.Die();

        animator.SetTrigger("Die");
        BattleManager.instance.EndRound(EndGame);
    }

    void OnHealthTextChanged(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    void OnArmorTextChanged(int newArmor)
    {
        armorText.text = newArmor.ToString();
    }

    void OnManaTextChanged(int newMana)
    {
        manaText.text = newMana.ToString();
    }

    public void Mana(int cost)
    {
        currentMana -= cost;

        if (OnManaChanged != null)
        {
            OnManaChanged(currentMana);
        }
    }

    // shitty fix
    public void ResetMana()
    {
        currentMana = maxMana;
        if (OnManaChanged != null)
        {
            OnManaChanged(currentMana);
        }
    }

    public void IncreaseMana(int ManaValue)
    {
        maxMana += ManaValue;
    }
}
