using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats {

    public static EnemyStats enemyStatsInstance;

    void Awake()
    {
        if (enemyStatsInstance != null && enemyStatsInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            enemyStatsInstance = this;
        }
    }

    string EndGame = "You won!";

    public Animator animator;

    public int maxHealth = 10;

    public Text healthText;
    public Text armorText;

    private void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;

        armor = 0;

        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthTextChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorTextChanged;
    }

    public override void Die()
    {
        base.Die();

        EnemyStats.enemyStatsInstance.animator.SetTrigger("Die");

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
}
