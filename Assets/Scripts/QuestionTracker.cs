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
    int questionsTotal;

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
                correct.Add(s, new List<Question>());
            }
        }
        questionsCorrect++;
        questionsTotal++;
        Debug.Log("QUESTIONS CORRECT: " + questionsCorrect);
        Debug.Log("QUESTIONS TOTAL: " + questionsTotal);
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
                incorrect.Add(s, new List<Question>());
            }
        }
        questionsIncorrect++;
        questionsTotal++;
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
        sb.Append("Accuracy: " + (double) questionsCorrect / questionsTotal * 100 + "%\n");

        foreach(string s in tags)
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
            sb.Append(s + ": " + (double) numCorrect / (numCorrect + numIncorrect) * 100
                + "%\n");
        }

        return sb.ToString();
    }
}
