using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Text moneyUI;
    public GameObject panel;
    public CanvasGroup shop;
    public CanvasGroup combat;

    public void Start()
    {
        UpdateMoney();
        panel.SetActive(false);
    }

    public void OnClick()
    {
        Money.SubtractMoney(1);
        UpdateMoney();
        CheckMoney();
    }

    public void AddItem (GameObject gameObject)
    {
        Debug.Log("Picking up item.");
        /* bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)*/
        Destroy(gameObject);
    }

    public void OnOk()
    {
        Helper.Switch(shop, combat);
    }

    public void CheckMoney() {
        if (Money.money <= 0)
        {
            panel.SetActive(true);
            moneyUI.enabled = false;
        }
    }

    public void UpdateMoney()
    {
        moneyUI.text = Money.money.ToString();
    }


}
