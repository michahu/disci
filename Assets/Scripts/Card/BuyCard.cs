using UnityEngine;

public class BuyCard : MonoBehaviour {

    public GameObject target;

    Card card;

    public void Buy()
    {
        card = target.GetComponent<CardDisplay>().card;
        Debug.Log("Buying card " + card.name);

        Hand.handInstance.Add(card);
    }

}
