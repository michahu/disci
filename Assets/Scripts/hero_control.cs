using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_control : MonoBehaviour {


    void Start() {

    }


    void Update () {

        if (Input.GetKeyDown ("space")) 
        {

            GetComponent<Animator> ().SetTrigger ("hero_melee");

            GetComponent<Transform> ().position = new Vector2 (-275.65f, 73.29f);

        }
    }

    void returnHero ()
    {

        GetComponent<Transform>().position = new Vector2 (-180f, -91f);

    }
}


