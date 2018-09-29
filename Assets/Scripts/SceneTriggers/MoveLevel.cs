using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour {

    [SerializeField] private string loadLevel;

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            SceneManager.LoadScene(loadLevel);
        }
    }
}









