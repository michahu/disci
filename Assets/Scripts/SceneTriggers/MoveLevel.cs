using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour {

    private string loadLevel = "Battle";

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            SceneManager.LoadScene(loadLevel);
        }
    }
}









