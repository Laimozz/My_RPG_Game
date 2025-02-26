using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    private readonly int bossAttack = Animator.StringToHash("BossAttack");
    private readonly int bossTakeHit = Animator.StringToHash("BossTakeHit");
    private readonly int bossDead = Animator.StringToHash("BossDead");

    [SerializeField] private Animator bossAnimations;

    [SerializeField] private GameObject enemyUI;

    private void Start()
    {
        bossAnimations = GetComponent<Animator>();

        enemyUI = GameObject.Find("EnemyUI");
    }
    private void Update()
    {
        if (enemyUI == null)
        {
            enemyUI = GameObject.Find("EnemyUI");
        }
    }

    public void AttackState()
    {
        bossAnimations.SetTrigger(bossAttack);
    }

    public void TakeHitState()
    {
        bossAnimations.SetTrigger(bossTakeHit);
    }

    public void DeadState() 
    { 
        bossAnimations.SetTrigger(bossDead);
        enemyUI.SetActive(false);
    }
}
