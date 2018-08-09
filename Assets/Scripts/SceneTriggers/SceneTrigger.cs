using System.Collections;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    public GameObject guiObject;
    public string LevelToLoad;

	void Start () {
        
        guiObject.SetActive(false);

	}
	// can be OnTriggerStay
    void OnTriggerEnter (Collider other) {

        if (other.gameObject.tag == "Player") {


            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {

                Application.LoadLevel(LevelToLoad);
            }
        }
		
	}

	void OnTriggerExit()
	{
        guiObject.SetActive(false);
	}
}
