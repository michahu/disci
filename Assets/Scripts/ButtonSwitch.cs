using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSwitch : MonoBehaviour {

    [SerializeField] private string loadLevel;

	public void changescene(string loadLevel)

    {

        SceneManager.LoadScene(loadLevel);
    }

}



