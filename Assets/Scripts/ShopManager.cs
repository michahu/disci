using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour {

    public Text moneyUI;
    public GameObject OutOfMoney;
    public GameObject CannotAfford;
    public Hand hand;

    public GameObject CardPrefab;

    public void Start()
    {
        UpdateMoney();
        OutOfMoney.SetActive(false);
        CannotAfford.SetActive(false);

        // loading each card

        // there is potentially better way
        Card[] cards = GameManager.instance.GetComponent<CardController>()
            .GetCardGroup(0).GetCards();

        for (int i = 0; i < cards.Length; i++)
        {
            Card c = cards[i];
            GameObject card = Instantiate(CardPrefab);
            card.transform.SetParent(this.transform);

            card.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = c.artwork;
            card.transform.GetChild(2).GetComponent<Text>().text = c.name;
            card.transform.GetChild(3).GetComponent<Text>().text = c.description ;
            card.transform.GetChild(4).GetComponent<Text>().text = c.cost.ToString();

            card.GetComponent<CardHelper>().card = c;
        }
    }

    public void Buy(GameObject card)
    {
        CardHelper c = card.GetComponent<CardHelper>();

        if (IsThereMoney(c.card.cost))
        {
            Debug.Log("Buying card " + card.name);

            hand.Add(card);

            Money.SubtractMoney(c.card.cost);
        }

        else return;

    }

    public bool IsThereMoney(int cost)
    {
        if (Money.money <= 0)
        {
            OutOfMoney.SetActive(true);
            return false;
        }

        if (Money.money < cost)
        {
            CannotAfford.SetActive(true);
            return false;
        }

        else return true;
    }

    public void UpdateMoney()
    {
        moneyUI.text = Money.money.ToString();
    }


}
