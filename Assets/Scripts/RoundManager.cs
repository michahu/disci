using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;

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

    private int roundNumber = 1;

    public int GetRoundNumber()
    {
        return roundNumber;
    }

    public void SetRoundNumber(int x)
    {
        this.roundNumber = x;
    }
}