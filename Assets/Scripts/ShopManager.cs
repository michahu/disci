using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class ShopManager : MonoBehaviour {

    public Text moneyUI;
    public GameObject OutOfMoney;
    public GameObject CannotAfford;
    public CanvasGroup shop;
    public CanvasGroup combat;
    public GameObject AdvButton; // shitty fix, wil remove

    GameObject[] cards;

    public void StartShop()
    {
        UpdateMoney();
        OutOfMoney.SetActive(false);
        CannotAfford.SetActive(false);
        // loading each card

        cards = GameObject.FindGameObjectsWithTag("Card").OrderBy(go => go.name).ToArray();;

        for (int j = 0; j < cards.Length; j++)
        {
            Debug.Log(cards[j].name);
        }

        int i = 0;
        foreach (GameObject card in cards)
        {
            card.GetComponent<CardDisplay>().LoadCard(i);
            i++;
        }
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
