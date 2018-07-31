using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour {

    public Transform handParent;

    Hand hand;

    CardUI[] cardSlots;

	// Use this for initialization
	void Start () {
        hand = Hand.handInstance;
        hand.onItemChangedCallback += UpdateUI;
        cardSlots = handParent.GetComponentsInChildren<CardUI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        
        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (i < hand.cards.Count)
            {
                cardSlots[i].AddCard(hand.cards[i]);
                Debug.Log("Added " + hand.cards[i].name);
            } else
            {
                // highly suspect
                cardSlots[i].Clear();
            }
        }
        Debug.Log("UPDATE UI");
    }
}
