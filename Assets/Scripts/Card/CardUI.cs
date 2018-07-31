using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public GameObject CardPrefab;

    Transform ui;
    Image artwork;
    Text name;
    Text description;
    Text cost;

    public void AddCard(Card newCard)
    {
        ui = Instantiate(CardPrefab).transform;
        ui.SetParent(this.transform);
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
