using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Shoes" , fileName = "Shoes")]
public class ShoesItem : InventoryItems
{
    public float shoesStatMp;
    public override void Equip(InventoryItems item, int index)
    {
        if (PlayerUI.Instance.shoesItems != null)
        {
            PlayerUI.Instance.shoesEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.shoesEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.shoesEquip.color = iconColor;
            InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.shoesItems, index);
            PlayerUI.Instance.shoesItems = item;
        }
        else
        {
            PlayerUI.Instance.shoesEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.shoesEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.shoesEquip.color = iconColor;
            PlayerUI.Instance.shoesItems = item;
            InventoryScript.Instance.SetQuantityInSlot(index, 1);
        }

        PlayerCtrl.Instance.PlayerStats.mp += shoesStatMp;
        PlayerCtrl.Instance.PlayerStats.maxMp += shoesStatMp;
    }
}
