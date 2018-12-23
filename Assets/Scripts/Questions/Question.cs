[System.Serializable]

public class Question {
    public string q;
    public string tags;
    public Answer ans;
    public string[] answers;
}

public enum Answer
{
    a,
    b,
    c,
    d
}
