using UnityEngine;

public class BuyCard : MonoBehaviour {

    public Card card;
    public CardUI cardUI;
    public Transform combatParent;

    public void Buy()
    {
        Debug.Log("Buying card " + card.name);
        Instantiate(cardUI, combatParent);
        Hand.handInstance.Add(card);
    }

}
