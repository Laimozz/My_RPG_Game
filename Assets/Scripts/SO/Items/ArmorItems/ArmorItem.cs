using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Armor" , fileName = "Armor")]
public class ArmorItem : InventoryItems
{
    public float armorStatHp;
    public override void Equip(InventoryItems item, int index)
    {
        if (PlayerUI.Instance.armorItems != null)
        {
            PlayerUI.Instance.armorEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.armorEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.armorEquip.color = iconColor;
            InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.armorItems, index);
            PlayerUI.Instance.armorItems = item;
        }
        else
        {
            PlayerUI.Instance.armorEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.armorEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.armorEquip.color = iconColor;
            PlayerUI.Instance.armorItems = item;
            InventoryScript.Instance.SetQuantityInSlot(index, 1);
        }

        PlayerCtrl.Instance.PlayerStats.hp += armorStatHp;
        PlayerCtrl.Instance.PlayerStats.maxHp += armorStatHp;
    }
}
