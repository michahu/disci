using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// may be temporary. 

public class CardHelper : MonoBehaviour, IPointerClickHandler{

    public Card card;
    private int RoundBought;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log(this.gameObject.ToString());

        // bandaid fix?
        if (this.transform.parent.name == "Shop Panel")
        this.gameObject.GetComponentInParent<ShopManager>().Buy(this.gameObject);
        RoundBought = GameManager.instance.RoundNumber;

    }


    void Update ()
    {
        // will have to set up ShopManager parent potentially
        if (Input.GetMouseButtonDown(1) && this.transform.parent.name == ("Deck"))
        {
            Deck.deckInstance.Remove(this.gameObject);
            Destroy(this.gameObject);

            if (GameManager.instance.RoundNumber == RoundBought)
                Money.AddMoney(card.goldCost);
            else Money.AddMoney((int) 0.5 * card.goldCost);

        }
    }
}
