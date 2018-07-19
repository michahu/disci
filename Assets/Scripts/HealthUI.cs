using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;

	// Use this for initialization
	void Start () {
		foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            ui = Instantiate(uiPrefab, c.transform).transform;
            ui.position = target.position;
            healthSlider = ui.GetChild(0).GetComponent<Image>();
            break;
        }
	}
	
	// Update is called once per frame
    // Update when taking damage
	void Update () {
		
	}
}
