using UnityEngine;

public enum ItemType
{
    Fruit,

    Spike,

    Potion,

}

[CreateAssetMenu(fileName = "New File Data", menuName = "Fruit/Spike/potion")]

public class ScriptableObjectItem : ScriptableObject
{
    public string itemName;

    public float valueAmount; // belom

    public Sprite itemIcon;

    public float damageTaken; // belom

    public ItemType type;

    public int effectValue;

}