using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Image artwork;
    public Text description;
    public Text cost;

    void Start()
    {
        nameText.text = card.name;
        artwork.sprite = card.artwork;
        description.text = card.description;
        cost.text = card.cost.ToString();
    }

}
