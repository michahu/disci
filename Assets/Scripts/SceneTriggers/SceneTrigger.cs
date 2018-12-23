using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour {

    // public GameObject guiObject;
    private string LevelToLoad = "Video";

	void Start () {
        
        //guiObject.SetActive(false);

	}
	// can be OnTriggerStay
    void OnTriggerEnter (Collider other) {

        SceneManager.LoadScene(LevelToLoad);
        //if (other.gameObject.tag == "Player") {
        //    guiObject.SetActive(true);
        //    if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
        //    {
        //        Application.LoadLevel(LevelToLoad);
        //        SceneManager.LoadScene(LevelToLoad);
        //    }
        //}
		
	}

	//void OnTriggerExit()
	//{
 //       guiObject.SetActive(false);
	//}
}
