using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck : MonoBehaviour {

    public static Deck deckInstance;

    void Awake()
    {
        if (deckInstance != null && deckInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            deckInstance = this;
        }
    }

    public List<GameObject> cardsInDeck = new List<GameObject>();

    public void Add(GameObject card)
    {
        cardsInDeck.Add(card);
        card.transform.SetParent(this.transform);
    }

    public void Remove(GameObject card)
    {
        cardsInDeck.Remove(card);
    }

    public GameObject Draw()
    {
        int i = cardsInDeck.Count - 1;
        GameObject c = cardsInDeck[i];
        // Debug.Log("Returning " + c.name);
        cardsInDeck.RemoveAt(i);
        return c;
    }

    public void ShuffleDeck()
    {
        System.Random rng = new System.Random();

        int n = cardsInDeck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = cardsInDeck[k];
            cardsInDeck[k] = cardsInDeck[n];
            cardsInDeck[n] = value;
        }
    }
}
