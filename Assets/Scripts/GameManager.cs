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

    // camera movement
    public Camera camera;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 velocity = Vector3.zero;

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
        p1 = new Vector3(336.63f, -119.92f, -2.15f);
        p2 = new Vector3(336.21f, -121.75f, 5.47f);
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
            StartCoroutine(MoveCamera(p1, p2, 1.0f));
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
        QuestionManager.questionManagerInstance.SubmitNewScores();
        EndGame = EndGame + "\n" + QuestionManager.questionManagerInstance.GetStats();
        RoundOverPanel.SetActive(true);
        RoundOverPanel.GetComponentInChildren<Text>().text = EndGame;
    }

    public void ReturnToEnvironment() 
    {
        SceneManager.LoadScene("Environment Scene");
    }

    IEnumerator MoveCamera(Vector3 p1, Vector3 p2, float duration) 
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            camera.transform.position = Vector3.Lerp(p1, p2, t / duration);
        }
        yield return 0;
    }

}


