using UnityEngine;

[System.Serializable]
public class CardComponent
{
    public ComponentType componentType;
    public int modifier;

    public virtual void Action() { }
}

public enum ComponentType
{
   Attack, Armor, Heal, Buff, Debuff
}