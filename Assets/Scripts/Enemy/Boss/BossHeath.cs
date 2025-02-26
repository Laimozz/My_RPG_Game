using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeath : EnemyHeath
{
    public override void TakeDamage(float dame)
    {
        transform.GetComponent<BossAnimation>().TakeHitState();
        base.TakeDamage(dame);
    }
    public override void Dead()
    {
        transform.GetComponent<BossAnimation>().DeadState();
        Destroy(gameObject, 2.5f);
    }
}
