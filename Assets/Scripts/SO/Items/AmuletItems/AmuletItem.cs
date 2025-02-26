using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Amulet" , fileName = "Amulet")]
public class AmuletItem :InventoryItems
{
    [SerializeField] public float amuletStatHp;
    [SerializeField] public float amuletStatMp;

    public override void Equip(InventoryItems item, int index)
    {
        if (PlayerUI.Instance.amuletItems != null)
        {
            PlayerUI.Instance.amuletEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.amuletEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.amuletEquip.color = iconColor;
            InventoryScript.Instance.ReplaceItem(PlayerUI.Instance.amuletItems, index);
            PlayerUI.Instance.amuletItems = item;
        }
        else
        {
            PlayerUI.Instance.amuletEquip.sprite = item.iconItem;
            Color iconColor = PlayerUI.Instance.amuletEquip.color;
            iconColor.a = 1f;
            PlayerUI.Instance.amuletEquip.color = iconColor;
            PlayerUI.Instance.amuletItems = item;
            InventoryScript.Instance.SetQuantityInSlot(index, 1);
        }

        PlayerCtrl.Instance.PlayerStats.hp += amuletStatHp;
        PlayerCtrl.Instance.PlayerStats.maxHp += amuletStatHp;

        PlayerCtrl.Instance.PlayerStats.mp += amuletStatMp;
        PlayerCtrl.Instance.PlayerStats.maxMp += amuletStatMp;
        
    }
}
