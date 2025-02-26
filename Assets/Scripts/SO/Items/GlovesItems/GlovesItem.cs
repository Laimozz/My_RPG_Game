using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Gloves" , fileName = "Gloves")]
public class GlovesItem : InventoryItems
{
    public float glovesStatDame;
    public override void Equip(InventoryItems item, int index)
    {
        if (PlayerUI.Instance.glovesItems != null)
        {
            PlayerUI.Instance.glovesEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.glovesEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.glovesEquip.color = iconColor;
            InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.glovesItems, index);
            PlayerUI.Instance.glovesItems = item;
        }
        else
        {
            PlayerUI.Instance.glovesEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.glovesEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.glovesEquip.color = iconColor;
            PlayerUI.Instance.glovesItems = item;
            InventoryScript.Instance.SetQuantityInSlot(index, 1);
        }
        PlayerCtrl.Instance.PlayerStats.damebasic += glovesStatDame;
        
    }
}
