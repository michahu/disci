using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public GameObject gameManager;
    public GameObject CardPrefab;

    Transform ui;
    CardData ShopCardData;
    Card[] AllCards;

    [HideInInspector]
    public Card card;

    Image artwork;
    Text name;
    Text description;
    Text cost;

    // for shop cards
    public void LoadCard(int i)
    {
        // setting the sample card and checking for null
        ShopCardData = gameManager.GetComponent<DataController>().allCards[0];
        AllCards = ShopCardData.cards;

        if (i < AllCards.Length)
        {

            card = AllCards[i];

            // instantiate Card prefab
            ui = Instantiate(CardPrefab).transform;
            ui.transform.SetParent(this.transform, false);
            ui.position = this.transform.position;

            // defining all components in instantiated prefab
            artwork = ui.GetChild(0).GetChild(0).GetComponent<Image>();
            name = ui.GetChild(2).GetComponent<Text>();
            description = ui.GetChild(3).GetComponent<Text>();
            cost = ui.GetChild(4).GetComponent<Text>();

            // uploading with desired components
            artwork.sprite = card.artwork;
            name.text = card.name;
            description.text = card.description;
            cost.text = card.cost.ToString();
        }

    }

    // for hand cards
    public void AddCard(Card newCard)
    {
        ui = Instantiate(CardPrefab).transform;
        ui.SetParent(this.transform, false);
        ui.position = this.transform.position;

        artwork = ui.GetChild(0).GetChild(0).GetComponent<Image>();
        name = ui.GetChild(2).GetComponent<Text>();
        description = ui.GetChild(3).GetComponent<Text>();
        cost = ui.GetChild(4).GetComponent<Text>();

        // uploading with desired components
        artwork.sprite = newCard.artwork;
        name.text = newCard.name;
        description.text = newCard.description;
        cost.text = newCard.cost.ToString();
    }

    public void Clear()
    {
        ui = null;
    }
}
