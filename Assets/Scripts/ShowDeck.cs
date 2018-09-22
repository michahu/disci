using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDeck : MonoBehaviour {

    public GameObject deck;
    private bool isVisible = false;

	// Use this for initialization
	void Start () {
        deck.SetActive(false);
	}
	
	// Update is called once per frame
	public void ToggleDeck () {
        deck.SetActive(!isVisible);
        isVisible = !isVisible;
	}
}
