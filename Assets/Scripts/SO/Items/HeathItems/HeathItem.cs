using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Items/HeathItem" , fileName = "HeathItem")]
public class HeathItem : InventoryItems
{
    [SerializeField] public float healingAmount;


    public override void Use()
    {
            if (PlayerCtrl.Instance.PlayerStats.hp > 0)
            {
                PlayerCtrl.Instance.PlayerStats.hp += Mathf.Ceil(PlayerCtrl.Instance.PlayerStats.maxHp/ healingAmount);
                if (PlayerCtrl.Instance.PlayerStats.hp >= PlayerCtrl.Instance.PlayerStats.maxHp)
                {
                    PlayerCtrl.Instance.PlayerStats.hp = PlayerCtrl.Instance.PlayerStats.maxHp;
                }
            }
        }  
}
