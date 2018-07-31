using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class ShopManager : MonoBehaviour {

    public Text moneyUI;
    public GameObject panel;
    public CanvasGroup shop;
    public CanvasGroup combat;
    public GameObject AdvButton; // shitty fix, wil remove

    public void StartShop()
    {
        UpdateMoney();
        panel.SetActive(false);
        // loading each card

        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        cards.OrderBy(gameObject => gameObject.name).ToArray();
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

    public void OnClick()
    {
        Money.SubtractMoney(1);
        UpdateMoney();
        CheckMoney();
    }

    public void CheckMoney() {
        if (Money.money <= 0)
        {
            panel.SetActive(true);
            // moneyUI.enabled = false;
        }
    }

    public void UpdateMoney()
    {
        moneyUI.text = Money.money.ToString();
    }


}
