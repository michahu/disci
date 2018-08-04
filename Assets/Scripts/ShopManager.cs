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
    public CanvasGroup shop;
    public CanvasGroup combat;
    public GameObject AdvButton; // shitty fix, wil remove

    GameObject[] cards;
    Card card;

    public void StartShop()
    {
        UpdateMoney();
        OutOfMoney.SetActive(false);
        CannotAfford.SetActive(false);
        // loading each card

        cards = GameObject.FindGameObjectsWithTag("ShopCard").OrderBy(go => go.name).ToArray();;

        for (int j = 0; j < cards.Length; j++)
        {
            Debug.Log(cards[j].name);
        }

        int i = 0;
        foreach (GameObject card in cards)
        {
            card.GetComponent<CardUI>().LoadCard(i);
            i++;
        }
    }

    public void Buy(GameObject target)
    {
        card = target.GetComponent<CardUI>().card;

        if (IsThereMoney(card.cost))
        {
            Debug.Log("Buying card " + card.name);

            Hand.handInstance.Add(card);

            Money.SubtractMoney(card.cost);
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
