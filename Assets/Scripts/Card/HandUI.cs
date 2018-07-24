using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour {

    public Transform combatGroup;

    Hand hand;

    CardUI[] cardUIs;

	// Use this for initialization
	void Start () {
        hand = Hand.handInstance;
        hand.onItemChangedCallback += UpdateUI;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        cardUIs = combatGroup.GetComponentsInChildren<CardUI>();
        for (int i = 0; i < cardUIs.Length; i++)
        {
            if (i < hand.cards.Count)
            {
                cardUIs[i].AddCard(hand.cards[i]);
                Debug.Log("Added " + hand.cards[i].name);
            } else
            {
                // highly suspect
                cardUIs[i].Clear();
            }
        }
        Debug.Log("UPDATE UI");
    }
}
