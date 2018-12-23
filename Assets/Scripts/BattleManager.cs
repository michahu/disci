using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class BattleManager : MonoBehaviour {

    public static BattleManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // canvas groups control the gameflow
    public CanvasGroup qa;
    public CanvasGroup feedback;
    public CanvasGroup shop;
    public CanvasGroup combat;

    // moving between canvas groups
    private CanvasGroup[] canvasGroups;
    private int gameState;

    // end round and timers
    public GameObject EndTurnButton;
    public GameObject RoundOverPanel;
    public int RoundNumber;

    // camera movement
    public Camera cam;
    private GameObject targetPosition;
    private Boolean moveToBattle;
    private Boolean moveToQuestion;
    public GameObject enemyStats;
    public GameObject playerStats;
    private Vector2 currentEnemyStatsUI;
    private Vector2 currentPlayerStatsUI;
    private Vector2 currentEnemyStatsUI1;
    private Vector2 currentPlayerStatsUI1;

    // Shop reference
    public GameObject hand;

    /*
     * 0 = qa
     * 1 = feedback
     * 2 = shop
     * 3 = combat
     */

    public void Start()
    {
        canvasGroups = new CanvasGroup[] {qa, feedback, shop, combat};
        gameState = 0;
        RoundNumber = 0;
        targetPosition = new GameObject();
  
        currentPlayerStatsUI = playerStats.GetComponent<RectTransform>().anchoredPosition;
        currentEnemyStatsUI = enemyStats.GetComponent<RectTransform>().anchoredPosition;
        currentPlayerStatsUI1 = new Vector2(-291, 38);
        currentEnemyStatsUI1 = new Vector2(240, 38);
        moveToQuestion = true;
        moveToBattle = false;
    }

    // don't like this
    public void Advance()
    {
        gameState = mod(gameState + 1, 4);
        // Debug.Log("GAMESTATE: " + gameState);
        Helper.Switch(canvasGroups[mod(gameState - 1, 4)], canvasGroups[gameState]);
        if (gameState == 0)
        {
            moveToQuestion = true;
            moveToBattle = false;
            QuestionManager.questionManagerInstance.GetQuestion();
            PlayerStats.playerStatsInstance.ResetMana();
            RoundNumber++;
        } else if (gameState == 3)
        {
            if (EnemyStats.enemyStatsInstance.poisoned == true) EnemyStats.enemyStatsInstance.Damage(1);
            moveToQuestion = false;
            moveToBattle = true;
            EndTurnButton.SetActive(true);
        }

    }

    private void Update()
    {
        if (moveToQuestion) 
        {
            targetPosition.transform.position = new Vector3(336.63f, -119.92f, -2.15f);
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition.transform.position, Time.deltaTime);
            playerStats.GetComponent<RectTransform>().anchoredPosition = currentPlayerStatsUI;
            enemyStats.GetComponent<RectTransform>().anchoredPosition = currentEnemyStatsUI;

        }
        else if (moveToBattle)
        {
            // moving cameras
            targetPosition.transform.position = new Vector3(336.21f, -121.75f, 5.47f);
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition.transform.position, Time.deltaTime);
            playerStats.GetComponent<RectTransform>().anchoredPosition = currentPlayerStatsUI1;
            enemyStats.GetComponent<RectTransform>().anchoredPosition = currentEnemyStatsUI1;

            // scaling cards
            foreach (Transform c in hand.transform)
            {
                c.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public void EndTurn ()
    {
        EndTurnButton.SetActive(false);
        EnemyStats.enemyStatsInstance.DoSomething();
        if (PlayerStats.playerStatsInstance.currentHealth > 0)
        Advance();
    }

    public void EndRound (string EndGame) 
    {
        QuestionManager.questionManagerInstance.SubmitNewScores();
        EndGame = EndGame + "\n" + QuestionManager.questionManagerInstance.GetStats();
        RoundOverPanel.SetActive(true);
        RoundOverPanel.GetComponentInChildren<Text>().text = EndGame;
    }

    public void ReturnToEnvironment() 
    {
        SceneManager.LoadScene("Environment");
    }
}


