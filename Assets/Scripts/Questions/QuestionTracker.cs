using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// in the future, we may want to move this to a dedicated 
// string data structure
public class QuestionTracker {

    Dictionary<string, List<Question>> correct;
    Dictionary<string, List<Question>> incorrect;
    List<string> tags;

    int questionsCorrect;
    int questionsIncorrect;
    public int questionsTotal;

    public QuestionTracker()
    {
        correct = new Dictionary<string, List<Question>>();
        incorrect = new Dictionary<string, List<Question>>();
        tags = new List<string>();
        questionsCorrect = 0;
        questionsIncorrect = 0;
        questionsTotal = 0;
    }

    public void Correct(Question question)
    {
        string[] tags = ReturnTags(question);
        foreach (string s in tags)
        {
            List<Question> temp = null;
            if (correct.TryGetValue(s, out temp)) {
                temp.Add(question);
            } else
            {
                temp = new List<Question>();
                temp.Add(question);
                correct.Add(s, temp);
            }
        }
        questionsCorrect++;
        questionsTotal++;
        //Debug.Log("QUESTIONS CORRECT: " + questionsCorrect);
        //int qc = 0;
        //foreach (KeyValuePair<string, List<Question>> set in correct)
        //{
        //    qc += set.Value.Count;
        //}
        //Debug.Log("Questions correct: " + qc);
    }

    public void Incorrect(Question question)
    {
        string[] tags = ReturnTags(question);
        foreach (string s in tags)
        {
            List<Question> temp = null;
            if (incorrect.TryGetValue(s, out temp))
            {
                temp.Add(question);
            }
            else
            {
                temp = new List<Question>();
                temp.Add(question);
                incorrect.Add(s, temp);
            }
        }
        questionsIncorrect++;
        questionsTotal++;
        //Debug.Log("QUESTIONS INCORRECT: " + questionsIncorrect);
        //int qc = 0;
        //foreach (KeyValuePair<string, List<Question>> set in incorrect)
        //{
        //    qc += set.Value.Count;
        //}
        //Debug.Log("Questions incorrect: " + qc);
    }

    private string[] ReturnTags(Question question)
    {
        string[] ret = question.tags.Split(new char[] { ',' });
        foreach (string s in ret)
        {
            if (!tags.Contains(s)) tags.Add(s);
        }
        return ret;
    }

    
    public string GetStats()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Questions Answered: " + questionsTotal + "\n");
        //sb.Append("Accuracy: " + (int) ((double) questionsCorrect / questionsTotal * 100) + "%\n");
        //sb.Append("Categories: ");
        //foreach (string s in tags)
        //{
        //    sb.Append(s + " ,");
        //}
        //sb.Append("\n");
        foreach (string s in tags)
        {
            int numCorrect = 0;
            int numIncorrect = 0;
            
            if (correct.ContainsKey(s))
            {
                numCorrect += correct[s].Count;
            }
            if (incorrect.ContainsKey(s))
            {
                numIncorrect += incorrect[s].Count;
            }
            sb.Append(s + ": " 
                + (numCorrect + numIncorrect) + " answered, "
                + (int) ((double) numCorrect / (numCorrect + numIncorrect) * 100)
                + "%\n");
        }
        sb.Append("Fastest Time: " + System.Math.Round(QuestionManager.questionManagerInstance.playerRecords.fastestTime, 2)
                 + "s/question");

        return sb.ToString();
    }
}
