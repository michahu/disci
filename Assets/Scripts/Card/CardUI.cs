using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public Image icon;

    Card card; 

    public void AddCard(Card newCard)
    {
        card = newCard;

        icon.sprite = newCard.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        card = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
