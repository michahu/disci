using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSwitch : MonoBehaviour {

    // private string loadLevel = "Battle";

	public void changeScene()
    {
        SceneManager.LoadScene("Battle");
    }

}



