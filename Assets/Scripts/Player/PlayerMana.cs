using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStatsSO;

    //void Update()
    //{
    //    if (playerStatsSO.hp <= 0) { return; }

    //    if (Input.GetKeyDown(KeyCode.M))
    //    {
    //        UseMana(10);
    //    }
    //}

    public void UseMana(float value)
    {
        if(playerStatsSO.mp >= value)
        {
            playerStatsSO.mp -= value;
            playerStatsSO.mp = Mathf.Ceil(playerStatsSO.mp);
        }
    }
}
