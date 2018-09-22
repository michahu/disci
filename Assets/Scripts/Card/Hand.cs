using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    private static Hand handInstance;

    private Hand() {
        cardsInHand = new List<GameObject>();
    }

    public static Hand HandInstance
    {
        get
        {
            if (handInstance == null)
            {
                handInstance = new Hand();
            }
            return handInstance;
        }
    }

    public List<GameObject> cardsInHand;
    const int HAND_SIZE = 4;

    private Deck d;

    public void Start()
    {
        d = Deck.deckInstance;
    }

    public void OnCombatBegin()
    {
        d.ShuffleDeck();
        // necessary because my draw method decrements cards
        int cardsInDeck = d.cardsInDeck.Count;
        for (int i = 0; i < cardsInDeck && i < HAND_SIZE; i++)
        {
            Add(d.Draw());
            // Debug.Log("Occurred " + i);
        }
    }

    public void Add(GameObject card)
    {
        // Debug.Log(this.gameObject.ToString());
        cardsInHand.Add(card);
        card.transform.SetParent(this.transform);
    }

    // ideally, remove nulls beforehand so you don't need to do the check
    public void OnCombatEnd()
    {
        // ideally this happens beforehand
        cardsInHand.RemoveAll(item => item == null);
        foreach (GameObject card in cardsInHand)
        {
            // if (card == null) cardsInHand.Remove(card);
            card.transform.SetParent(d.transform);
        }

        d.cardsInDeck.AddRange(cardsInHand);
        cardsInHand.Clear();
        d.ShuffleDeck();
    }
}
