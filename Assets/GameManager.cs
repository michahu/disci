using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
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
    public GameObject trans;

    // turning on combat system
    public static bool inCombat;

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
        trans.SetActive(false);

        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<Question>();
        }
        GetQuestion();
    }
    public void Advance()
    {
        gameState = mod(gameState + 1, 4);
        Debug.Log("GAMESTATE: " + gameState);
        Helper.Switch(canvasGroups[mod(gameState - 1, 4)], canvasGroups[gameState]);
        if (gameState == 0) trans.SetActive(false);
        else trans.SetActive(true);

        // setting up attack only if at that stage
        if (gameState == 3) inCombat = true;
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
    void GetQuestion()
    {
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
        feedbackText.text = "GOTCHA BITCH";
    }
    public void Correct()
    {
        Money.AddMoney(1);
        feedbackText.text = "Correct!";
    }
}


