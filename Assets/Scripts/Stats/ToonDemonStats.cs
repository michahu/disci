using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToonDemonStats : CharacterStats {

    public static ToonDemonStats toonDemonStatsInstance;

    void Awake()
    {
        if (toonDemonStatsInstance != null && toonDemonStatsInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            toonDemonStatsInstance = this;
        }
    }
    string EndGame = "You won!";

    private int maxHealth = 15;
    public bool poisoned;
    public int dodge = 50;

    public Text healthText;
    public Text armorText;
    public Text nextAction;

    private string enemyActionsFileName = "ToonDemon.json";
    private EnemyActions enemyActions;

    private void Start()
    {
        enemyActions = new EnemyActions(LoadEnemyActions());
        // SaveGameData();
        UpdateNextAction();


        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;

        armor = 0;

        healthText.text = currentHealth.ToString();
        armorText.text = armor.ToString();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthTextChanged;
        GetComponent<CharacterStats>().OnArmorChanged += OnArmorTextChanged;
    }

    private void UpdateNextAction()
    {
        nextAction.text = enemyActions.GetNextAction().explanation;
    }

    public void DoSomething()
    {
        this.enemyActions.PerformAction();
        UpdateNextAction();
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

        string filePath = Application.dataPath + "/StreamingAssets/ToonDemon.json";
        Debug.Log("file path: " + filePath);
        File.WriteAllText(filePath, dataAsJson);
    }
}

