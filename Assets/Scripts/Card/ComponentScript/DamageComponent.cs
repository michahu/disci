using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
// [CreateAssetMenu(fileName = "Damage Component", menuName = "Components/Damage")]
public class DamageComponent : CardComponent {

    private int DamageValue;

    public DamageComponent(int value)
    {
        this.DamageValue = value;
    } 

    public void Damage()
    {
        Debug.Log("Dealt " + DamageValue + " damage.");
    }
}
