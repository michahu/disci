using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {

    public List<CardComponent> cardComponents = new List<CardComponent>();

    private void AddComponent(CardComponent c)
    {
        cardComponents.Add(c);
    }
    
    public new string name;
    public Sprite artwork;
    public string description;
    public int cost;
}
