using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : ScriptableObject {
    
    new public string name = "New Item";
    public Sprite icon = null;

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;
}

public enum EquipmentSlot { Damage, Spell, Trap, Armor, Dodge, Heal}
