using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    protected override void Start()
    {
        enemyHeath = GetComponent<EnemyHeath>();
    }

    protected override void Update()
    {
        
    }
}
