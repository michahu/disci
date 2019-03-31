using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject panel;
    private bool tutorial = true;
    public Text instruction;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);

        if (tutorial) 
            instruction.text =
            "Welcome to Disci and thank you for trying out our game! " +
            "The controls for your character are WASD or the arrow keys." +
            "To exit the game at any time, press cmd-Q or ctrl-d" +
            "Move your character to the Tutorial gate and follow the prompts-"
            + "hope you enjoy!";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            panel.SetActive(false);
    }
}
