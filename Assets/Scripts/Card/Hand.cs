using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    #region Singleton

    public static Hand instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    
    public List<GameObject> cards = new List<GameObject>();

    public void Add(GameObject card)
    {
        cards.Add(card);
        card.transform.SetParent(this.transform);
        Debug.Log("Card added to hand.");
    }

    public void Remove(GameObject card)
    {
        cards.Remove(card);
        Destroy(card);
    }
}
