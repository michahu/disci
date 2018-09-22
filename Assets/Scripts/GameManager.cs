using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

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
    }

    // don't like this
    public void Advance()
    {
        gameState = mod(gameState + 1, 4);
        // Debug.Log("GAMESTATE: " + gameState);
        Helper.Switch(canvasGroups[mod(gameState - 1, 4)], canvasGroups[gameState]);
        if (gameState == 0)
        {
            QuestionManager.questionManagerInstance.GetQuestion();
            PlayerStats.playerStatsInstance.ResetMana();
            RoundNumber++;
        } else if (gameState == 3)
        {
            EndTurnButton.SetActive(true);
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
        EndGame = EndGame + "\n" + QuestionManager.questionManagerInstance.GetStats();
        RoundOverPanel.SetActive(true);
        RoundOverPanel.GetComponentInChildren<Text>().text = EndGame;
    }

    public void ReturnToEnvironment() 
    {
        SceneManager.LoadScene("Environment Scene");
    }

}


