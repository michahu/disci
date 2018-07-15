using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class panelopen : MonoBehaviour
{

    public GameObject Panel;
    int counter;

    public void showhidepanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            Panel.gameObject.SetActive (false);

        } else { 
        
            Panel.gameObject.SetActive (true);
        
        }
    }
}


