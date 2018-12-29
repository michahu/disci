using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour {

    public GameObject x;
    private bool isVisible = false;

	// Use this for initialization
	void Start () {
        x.SetActive(false);
	}
	
	// Update is called once per frame
	public void Toggle () {
        x.SetActive(!isVisible);
        isVisible = !isVisible;
	}
}
