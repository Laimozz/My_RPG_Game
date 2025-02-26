using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Pant", fileName = "Pant")]
public class PantItem : InventoryItems
{
    public float pantStatHp;
    public override void Equip(InventoryItems item, int index)
    {
        if (PlayerUI.Instance.pantItems != null)
        {
            PlayerUI.Instance.pantEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.pantEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.pantEquip.color = iconColor;
            InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.pantItems, index);
            PlayerUI.Instance.pantItems = item;
        }
        else
        {
            PlayerUI.Instance.pantEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.pantEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.pantEquip.color = iconColor;
            PlayerUI.Instance.pantItems = item;
            InventoryScript.Instance.SetQuantityInSlot(index, 1);
        }

        PlayerCtrl.Instance.PlayerStats.hp += pantStatHp;
        PlayerCtrl.Instance.PlayerStats.maxHp += pantStatHp;
    }
}
