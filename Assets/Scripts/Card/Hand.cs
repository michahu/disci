using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public static Hand handInstance;

    private void Awake()
    {
        if (handInstance != null)
        {
            Debug.Log("More than one hand instance");
            return;
        }
        handInstance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Card> cards = new List<Card>();

    public void Add(Card c)
    {
        cards.Add(c);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(Card c)
    {
        cards.Remove(c);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
