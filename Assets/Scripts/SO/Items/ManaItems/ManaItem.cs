using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/ManaItem", fileName = "ManaItem")]
public class ManaItem : InventoryItems
{
    [SerializeField] public float manaRecover;

    public override void Use()
    {
            PlayerCtrl.Instance.PlayerStats.mp += Mathf.Ceil(PlayerCtrl.Instance.PlayerStats.maxMp/manaRecover);
            if (PlayerCtrl.Instance.PlayerStats.mp >= PlayerCtrl.Instance.PlayerStats.maxMp)
            {
                PlayerCtrl.Instance.PlayerStats.mp = PlayerCtrl.Instance.PlayerStats.maxMp;
            }
        }         
}
