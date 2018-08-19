using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour {

    public static QuestionManager questionManagerInstance;

    public static QuestionManager Instance { get { return questionManagerInstance; } }

    private void Awake()
    {
        if (questionManagerInstance != null && questionManagerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            questionManagerInstance = this;
        }
    }

    private Question[] questions;
    private string gameDataFileName = "questions.json";


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

    public Text timeRemainingPanel;
    private bool isQuestionActive;
    private float timeRemaining;
    private float timeTotal = 10f;

    // Use this for initialization
    void Start () {
        questions = LoadGameData();

        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<Question>();
        }
        GetQuestion();
    }

    // Update is called once per frame
    void Update () {
        if (isQuestionActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemaining();

            if (timeRemaining <= 0f)
            {
                Incorrect();
                GameManager.instance.Advance();
            }
        }
    }

    public void GetQuestion()
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
        GameManager.instance.Advance();
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
        GameManager.instance.Advance();
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
        GameManager.instance.Advance();
        
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
        GameManager.instance.Advance();
    }

    private void Incorrect()
    {
        isQuestionActive = false;
        int correct = (int)currentQuestion.ans;
        feedbackText.text = "The correct answer was \"" + currentQuestion.answers[correct] + "\"";
    }
    public void Correct()
    {
        isQuestionActive = false;
        Money.AddMoney(1);
        feedbackText.text = "Correct!";
    }

    private Question[] LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            Debug.Log("File exists");
            string dataAsJson = File.ReadAllText(filePath);
            return JsonHelper.getJsonArray<Question>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load question data");
            return null;
        }
    }
    private void UpdateTimeRemaining()
    {
        timeRemainingPanel.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

}
