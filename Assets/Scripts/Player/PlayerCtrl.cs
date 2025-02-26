using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] private PlayerAnimations playerAnimations;
    [SerializeField] private PlayerHeath playerHeath;
    [SerializeField] private PlayerMana playerMana;
    [SerializeField] private PlayerExp playerExp;

    public PlayerAnimations PlayerAnimations => playerAnimations;
    public PlayerHeath PlayerHeath => playerHeath;
    public PlayerMana PlayerMana => playerMana;
    public PlayerExp PlayerExp => playerExp;

    //public static PlayerCtrl Instance;

    private void Start()
    {
        //if(Instance == null)
        //{
        //    Instance = this;
        //}
        playerAnimations = GetComponent<PlayerAnimations>();

        playerHeath = GetComponent<PlayerHeath>();

        playerMana = GetComponent<PlayerMana>();

        playerExp = GetComponent<PlayerExp>();
    }
    public PlayerStatsSO PlayerStats => playerStats;

    public void ResetPlayer()
    {
        playerAnimations.ReviveState();
        playerStats.ResetStats();
    }

}
