using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject CardPrefab;
    public Transform target;
    DataController dataController;

    Transform ui;
    CardData ShopCardData;
    Card[] AllCards;
    Card template;

    Image artwork;
    Text name;
    Text description;
    Text cost;

    public void LoadCard(int i)
    {
        // setting the sample card and checking for null
        ShopCardData = gameManager.GetComponent<DataController>().allCards[0];
        AllCards = ShopCardData.cards;

        if (i < AllCards.Length)
        {

            template = AllCards[i];

            // instantiate Card prefab
            ui = Instantiate(CardPrefab).transform;
            ui.SetParent(target.transform);
            ui.position = target.position;

            // defining all components in instantiated prefab
            artwork = ui.GetChild(0).GetChild(0).GetComponent<Image>();
            name = ui.GetChild(2).GetComponent<Text>();
            description = ui.GetChild(3).GetComponent<Text>();
            cost = ui.GetChild(4).GetComponent<Text>();

            // uploading with desired components
            artwork.sprite = template.artwork;
            name.text = template.name;
            description.text = template.description;
            cost.text = template.cost.ToString();
        }

    }
}