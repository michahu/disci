using UnityEngine;

public class BuyCard : MonoBehaviour {

    public GameObject shopManager;
    public GameObject target;

    Card card;

    public void Buy()
    {
        card = target.GetComponent<CardDisplay>().card;

        if (shopManager.GetComponent<ShopManager>().IsThereMoney(card.cost))
        {
            Debug.Log("Buying card " + card.name);

            Hand.handInstance.Add(card);

            Money.SubtractMoney(card.cost);

        }

        else return;

    }

}
