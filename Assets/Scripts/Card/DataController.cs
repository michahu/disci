using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public CardData[] allCards;

	// Use this for initialization
	void Start () {
        foreach (Card c in allCards[0].cards)
        {
            List<CardComponent> temp = new List<CardComponent>();
            foreach (CardComponent component in c.cardComponents)
            {
                AddComponent(temp, component.componentType, component.modifier);
            }
            c.cardComponents = temp;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // surprisingly, this is optimal. Switch statements are implemented as jump table in C#.
    // source: https://blogs.msdn.microsoft.com/abhinaba/2006/12/18/switches-and-jump-tables/
    void AddComponent(List<CardComponent> cardComponents, ComponentType componentType, int modifier)
    {
        switch (componentType)
        {
            case ComponentType.Armor:
            {
                    cardComponents.Add(new ArmorComponent(modifier));
                    Debug.Log("Added ArmorComponent.");
                    break;
            }
            case ComponentType.Attack:
            {
                    cardComponents.Add(new DamageComponent(modifier));
                    Debug.Log("Added DamageComponent.");
                    break;
            }
            case ComponentType.Buff:
            {
                    Debug.Log("Not implemented");
                    break;
            }
            case ComponentType.Debuff:
            {
                    Debug.Log("Not implemented");
                    break;
            }
            case ComponentType.Heal:
            {
                    cardComponents.Add(new HealComponent(modifier));
                    Debug.Log("Not implemented");
                    break;
            }
        }
    }
}
