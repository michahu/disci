using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// [CreateAssetMenu(fileName = "Damage Component", menuName = "Components/Damage")]
public class DamageComponent : CardComponent {

    public int DamageValue;

    public void Damage()
    {
        Debug.Log("Dealt damage.");
    }
}
