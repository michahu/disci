using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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

    public int maxHealth;

    public Text healthText;
    public Text armorText;

    private string enemyActionsFileName = "enemy.json";
    private EnemyActions enemyActions;

    private void Start()
    {
        enemyActions = new EnemyActions(LoadEnemyActions());
        // SaveGameData();

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;

        armor = 0;

        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthTextChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorTextChanged;
    }

    public void DoSomething()
    {
        this.enemyActions.PerformAction();
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

    private EnemyActions LoadEnemyActions()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, enemyActionsFileName);

        if (File.Exists(filePath))
        {
            // Debug.Log("File exists");
            string dataAsJson = File.ReadAllText(filePath);
            return JsonUtility.FromJson<EnemyActions>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load enemy data");
            return null;
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(enemyActions);

        string filePath = Application.dataPath + "/StreamingAssets/enemy.json";
        Debug.Log("file path: " + filePath);
        File.WriteAllText(filePath, dataAsJson);
    }
}
