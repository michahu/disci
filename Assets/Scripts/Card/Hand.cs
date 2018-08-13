using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    private List<GameObject> cardsInHand = new List<GameObject>();
    private int HAND_SIZE = 6;

    private Deck d;

    public void Start()
    {
        d = Deck.deckInstance;
    }

    public void OnCombatBegin()
    {
        d.ShuffleDeck();

        for (int i = 0; i < d.cardsInDeck.Count && i < HAND_SIZE; i++)
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

    // there's something odd about the transform business that
    // I need to think about
    public void OnCombatEnd()
    {
        d.cardsInDeck.AddRange(cardsInHand);
        cardsInHand.Clear();
        d.ShuffleDeck();

        foreach (Transform t in this.transform)
        {
            t.transform.SetParent(Deck.deckInstance.transform);
        }
    }
}
