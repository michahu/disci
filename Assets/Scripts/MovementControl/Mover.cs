using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public Animator move;

    void Start()
    {

        move = GetComponent<Animator>();
    }

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)) ||
            (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))

        {

            move.Play("Run_SwordShield");

        }

        if ((Input.GetKeyUp(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.RightArrow)) ||
           (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)))

        {

            move.Play("Idle_SwordShield");

        }

       

    }
}



