using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon" , fileName ="Weapon")]
public class WeaponItem : InventoryItems
{
    [SerializeField] public float damePlus;

    public override void Equip(InventoryItems item , int index)
    {
            if(PlayerUI.Instance.weaponItems != null)
            {
                PlayerUI.Instance.weaponEquip.sprite = item.iconItem;
                Color iconColor = PlayerUI.Instance.weaponEquip.color;
                iconColor.a = 1f;
                PlayerUI.Instance.weaponEquip.color = iconColor;
                InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.weaponItems, index);
                PlayerUI.Instance.weaponItems = item;
            }
            else
            {
                PlayerUI.Instance.weaponEquip.sprite = item.iconItem;
                Color iconColor = PlayerUI.Instance.weaponEquip.color;
                iconColor.a = 1f;
                PlayerUI.Instance.weaponEquip.color = iconColor;
                PlayerUI.Instance.weaponItems = item;
                InventoryScript.Instance.SetQuantityInSlot(index, 1);
            }

            PlayerCtrl.Instance.PlayerStats.damebasic += damePlus;
    }
}
