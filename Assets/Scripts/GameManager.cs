using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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

    public Question[] questions;

    // canvas groups control the gameflow
    public CanvasGroup qa;
    public CanvasGroup feedback;
    public CanvasGroup shop;
    public CanvasGroup combat;

    // question tracking
    private static List<Question> unanswered;
    private Question currentQuestion;

    // attach on screen text to question
    public Text questionText;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text feedbackText;

    // moving between canvas groups
    private CanvasGroup[] canvasGroups;
    private int gameState;

    // end round and timers
    public GameObject RoundOverPanel;
    public Text timeRemainingPanel;
    private bool isQuestionActive;
    private float timeRemaining;
    private float timeTotal = 10f;

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

        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<Question>();
        }
        GetQuestion();
    }

    // don't like this
    public void Advance()
    {
        gameState = mod(gameState + 1, 4);
        Debug.Log("GAMESTATE: " + gameState);
        Helper.Switch(canvasGroups[mod(gameState - 1, 4)], canvasGroups[gameState]);
        if (gameState == 0)
        {
            GetQuestion();
            PlayerStats.playerStatsInstance.ResetMana();
        }
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
    void GetQuestion()
    {
        isQuestionActive = true;
        timeRemaining = timeTotal;

        int rand = UnityEngine.Random.Range(0, unanswered.Count);
        currentQuestion = unanswered[rand];

        questionText.text = currentQuestion.q;
        a1.text = currentQuestion.answers[0];
        a2.text = currentQuestion.answers[1];
        a3.text = currentQuestion.answers[2];
        a4.text = currentQuestion.answers[3];

        unanswered.RemoveAt(rand);
    }

    public void UserSelectA()
    {
        if (currentQuestion.ans == Answer.a)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
        Advance();
    }
    public void UserSelectB()
    {
        if (currentQuestion.ans == Answer.b)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
        Advance();
    }
    public void UserSelectC()
    {
        if (currentQuestion.ans == Answer.c)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
        Advance();
    }
    public void UserSelectD()
    {
        if (currentQuestion.ans == Answer.d)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
        Advance();
    }
    private void Incorrect()
    {
        isQuestionActive = false;
        int correct = (int) currentQuestion.ans;
        feedbackText.text = "The correct answer was \"" + currentQuestion.answers[correct] + "\"";
    }
    public void Correct()
    {
        isQuestionActive = false;
        Money.AddMoney(1);
        feedbackText.text = "Correct!";
    }

    private void UpdateTimeRemaining()
    {
        timeRemainingPanel.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    void Update ()
    {
        if (isQuestionActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemaining();

            if (timeRemaining <= 0f)
            {
                Incorrect();
                Advance();
            }
        }
    }

    public void EndRound (string EndGame) 
    {
        RoundOverPanel.SetActive(true);
        RoundOverPanel.GetComponentInChildren<Text>().text = EndGame;
    }

    public void ReturnToEnvironment() 
    {
        SceneManager.LoadScene("Environment Scene");
    }
}


