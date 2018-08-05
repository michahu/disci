using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : CardComponent {

    private int HealValue;

    public HealComponent(int value)
    {
        this.HealValue = value;
    }

    public virtual void Heal()
    {
        Debug.Log("Armored up for " + HealValue + " .");
    }
}
