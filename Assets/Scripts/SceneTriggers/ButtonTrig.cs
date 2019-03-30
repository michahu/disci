using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTrig : MonoBehaviour {

    [SerializeField] private string loadLevel;
    public GameObject guiObject;

	void Start () {

        guiObject.SetActive(false);
		
	}

	void OnTriggerStay (Collider other)
	{
		
        if (other.gameObject.tag == "Player") {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E)) {

                SceneManager.LoadScene(loadLevel);
            }
        }
	}

	void OnTriggerExit()
	{

        guiObject.SetActive(false);
	}

}












