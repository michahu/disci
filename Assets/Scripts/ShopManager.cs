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
    public Deck deck;
    public GameObject CardPrefab;

    private bool displayActive;
    private float displayTime;

    public void Start()
    {
        OnShop();
        deck = Deck.deckInstance;

        // there is potentially better way
        Card[] cards = GameManager.instance.GetComponent<CardController>()
            .GetCardGroup(0).cards;

        for (int i = 0; i < cards.Length; i++)
        {
            Card c = cards[i];
            GameObject card = CreateCard(c);
        }
    }

    public void OnShop()
    {
        UpdateMoney();
        OutOfMoney.SetActive(false);
        CannotAfford.SetActive(false);
    }

    public void Buy(GameObject card)
    {
        CardHelper c = card.GetComponent<CardHelper>();

        if (IsThereMoney(c.card.goldCost))
        {
            Debug.Log("Buying card " + c.name);
            deck.Add(CopyCard(card));
            Money.SubtractMoney(c.card.goldCost);
            UpdateMoney();
        }
        else return;
    }

    public bool IsThereMoney(int cost)
    {
        if (Money.money <= 0)
        {
            OutOfMoney.SetActive(true);
            displayTime = 1f;
            return false;
        }
        if (Money.money < cost)
        {
            CannotAfford.SetActive(true);
            displayTime = 1f;
            return false;
        }
        else return true;
    }

    void Update ()
    {
        if (OutOfMoney.activeSelf)
        {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0)
            {
                OutOfMoney.SetActive(false);
            }
        }

        if (CannotAfford.activeSelf)
        {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0)
            {
                CannotAfford.SetActive(false);
            }
        }
    }

    public void UpdateMoney()
    {
        moneyUI.text = Money.money.ToString();
    }

    public GameObject CreateCard(Card c)
    {
        GameObject newCard = Instantiate(CardPrefab);
        newCard.transform.SetParent(this.transform, false);

        newCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = c.artwork;
        newCard.transform.GetChild(2).GetComponent<Text>().text = c.name;
        newCard.transform.GetChild(3).GetComponent<Text>().text = c.description;
        newCard.transform.GetChild(4).GetComponent<Text>().text = c.goldCost.ToString();
        newCard.transform.GetChild(5).GetComponent<Text>().text = c.manaCost.ToString();

        newCard.GetComponent<CardHelper>().card = c;

        return newCard;
    }


    public GameObject CopyCard(GameObject card)
    {
        GameObject newCard = Instantiate(CardPrefab);
        newCard.transform.SetParent(this.transform, false);

        newCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite
            = card.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
        newCard.transform.GetChild(2).GetComponent<Text>().text = card.transform.GetChild(2).GetComponent<Text>().text;
        newCard.transform.GetChild(3).GetComponent<Text>().text = card.transform.GetChild(3).GetComponent<Text>().text;
        newCard.transform.GetChild(4).GetComponent<Text>().text = card.transform.GetChild(4).GetComponent<Text>().text;
        newCard.transform.GetChild(5).GetComponent<Text>().text = card.transform.GetChild(5).GetComponent<Text>().text;

        newCard.GetComponent<CardHelper>().card = card.GetComponent<CardHelper>().card;

        return newCard;
    }
}
