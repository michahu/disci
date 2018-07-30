using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Text moneyUI;
    public GameObject panel;
    public CanvasGroup shop;
    public CanvasGroup combat;
    public GameObject AdvButton; // shitty fix, wil remove

    Transform cardUI;

    public void StartShop()
    {
        UpdateMoney();
        panel.SetActive(false);

        // loading each card

        // int i = 0;
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card")){
            card.GetComponent<CardDisplay>().LoadCard();

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
