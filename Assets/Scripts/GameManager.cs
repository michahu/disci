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

    public static GameManager Instance { get { return instance; } }

    private void Awake()
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
    }

    // don't like this
    public void Advance()
    {
        gameState = mod(gameState + 1, 4);
        Debug.Log("GAMESTATE: " + gameState);
        Helper.Switch(canvasGroups[mod(gameState - 1, 4)], canvasGroups[gameState]);
        if (gameState == 0)
        {
            QuestionManager.questionManagerInstance.GetQuestion();
            PlayerStats.playerStatsInstance.ResetMana();
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
        StartCoroutine(EndTurnAnimation());
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

    IEnumerator EndTurnAnimation () 
    {
        EnemyStats.enemyStatsInstance.animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1.5f);
        PlayerStats.playerStatsInstance.animator.SetTrigger("On Hit");
        PlayerStats.playerStatsInstance.Damage(2);
        yield return new WaitForSeconds(1f);

        Advance();
    }
}


