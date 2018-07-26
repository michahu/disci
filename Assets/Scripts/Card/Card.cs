using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Card")]
public class Card : ScriptableObject {
    
    public new string name;
    public Sprite artwork;
    public string description;
    public int cost;
}
