using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTrig : MonoBehaviour {

    [SerializeField] private string loadLevel;
    public GameObject panel;
    public Text instruction;

	void OnTriggerStay (Collider other)
	{
        instruction.text = "Jump into your first video by pressing [E] on your keyboard!";
        if (other.gameObject.tag == "Player") {
            panel.SetActive(true);
            if (panel.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E)) {

                SceneManager.LoadScene(loadLevel);
            }
        }
	}

	void OnTriggerExit()
	{
        panel.SetActive(false);
	}

}












