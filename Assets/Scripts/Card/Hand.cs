using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    
    public List<GameObject> cards = new List<GameObject>();
    public Transform test;

    public void Add(GameObject card)
    {
        Debug.Log(this.gameObject.ToString());
        cards.Add(card);
        Debug.Log("THIS TRANSFORM IS: " + test);
        card.transform.SetParent(test);
        Debug.Log("Card added to hand.");
    }

    public void Remove(GameObject card)
    {
        cards.Remove(card);
        Destroy(card);
    }
}
