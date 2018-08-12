using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// may be temporary. 

public class CardHelper : MonoBehaviour, IPointerClickHandler{

    public Card card;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log(this.gameObject.ToString());

        // bandaid fix?
        if (this.transform.parent.name == "Shop Panel")
        this.gameObject.GetComponentInParent<ShopManager>().Buy(this.gameObject);
    }
}
