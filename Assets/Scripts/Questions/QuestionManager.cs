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
    private string gameDataFileName;


    // question tracking
    private static List<Question> unanswered;
    // private static List<Question> correct;
    // private static List<Question> incorrect;
    private Question currentQuestion;
    // private int questionCount = 0;
    private QuestionTracker questionTracker;

    // attach on screen text to question
    public Text questionText;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text feedbackText;

    public Text timeRemainingPanel;
    private bool isQuestionActive;
    private float elapsedTime;
    // private float timeTotal = 10f;
    const float maxTime = 30f;
    public float totalTime = 0f;
    public PlayerRecords playerRecords;

    // Use this for initialization
    void Start () {

        int roundNumber;
        if (RoundManager.instance == null) roundNumber = 1;
        else roundNumber = RoundManager.instance.GetRoundNumber();

        gameDataFileName = Application.dataPath + "/StreamingAssets/Video" + roundNumber + ".json";

        questions = LoadGameData();
        // correct = new List<Question>();
        // incorrect = new List<Question>();
        // questionCount = 0;
        questionTracker = new QuestionTracker();
        playerRecords = new PlayerRecords();
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
            elapsedTime += Time.deltaTime;
            UpdateTimeRemaining();

            if (elapsedTime >= maxTime)
            {
                Incorrect();
                BattleManager.instance.Advance();
            }
        }
    }

    public void SubmitNewScores()
    {
        double averageTime = (double)totalTime / questionTracker.questionsTotal;
        if (averageTime > playerRecords.fastestTime) playerRecords.fastestTime = averageTime;
    }

    public string GetStats()
    {
        //string ret = "";
        //ret += "Accuracy: " 
        //    + (correct.Count() / questionCount * 100).ToString()
        //    + "%";
        //return ret;
        return questionTracker.GetStats();
    }

    public void GetQuestion()
    {
        // bandaid fix for if we run out of questions
        if (unanswered.Count == 0) unanswered = questions.ToList<Question>();

        isQuestionActive = true;
        elapsedTime = 0;

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
        BattleManager.instance.Advance();
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
        BattleManager.instance.Advance();
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
        BattleManager.instance.Advance();
        
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
        BattleManager.instance.Advance();
    }

    private void Incorrect()
    {
        double questionTime = elapsedTime;
        totalTime += elapsedTime;
        questionTracker.Incorrect(currentQuestion);
        isQuestionActive = false;
        feedbackText.text = "The correct answer was \"" + currentQuestion.answers[(int)currentQuestion.ans] + "\"";
        // questionCount++;
    }
    public void Correct()
    {
        // correct.Add(currentQuestion);
        double questionTime = elapsedTime;
        totalTime += elapsedTime;
        questionTracker.Correct(currentQuestion);
        isQuestionActive = false;
        Money.AddMoney(1);
        feedbackText.text = "Correct!";
        // questionCount++;
    }

    private Question[] LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Debug.Log("File exists");
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
        timeRemainingPanel.text = "Time: " + Mathf.Round(elapsedTime).ToString();
    }

}
