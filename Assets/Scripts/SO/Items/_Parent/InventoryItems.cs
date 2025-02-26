using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(menuName ="Items" , fileName = "InventoryItems")]
public class InventoryItems : ScriptableObject
{
    public string idItem;

    public string nameItem;

    public string levelNeeded;

    public float price;

    public Sprite iconItem;

    public bool isComsumable;

    public bool isEquip;

    public bool isStack;

    public float maxStack;

    [TextArea] public string descriptionItem;

    public ItemType itemType;

    public float dropChance;

    public virtual InventoryItems InstantiateItem()
    {
        InventoryItems item = Instantiate(this);
        return item;
    }

    public virtual void Use()
    {
        
    }

    public virtual void Equip(InventoryItems item , int index)
    {

    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Pant,
    Amulet,
    Gloves,
    Shoes,
    Heath,
    Mana,
}
