using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyActions
{
    [SerializeField] private LayerMask playerMask;

    [SerializeField] private Vector2 pointA;
    [SerializeField] private Vector2 pointB;

    [SerializeField] private GameObject enemyBullet;

    private float timerToFire = 0f;
    [SerializeField] private float timeBwFire;

    [SerializeField] private float dameToPlayer;
    private bool isAttacking;

    public bool IsAttacking => isAttacking;
    private void Update()
    {
        if(PlayerCtrl.Instance.PlayerStats.hp <= 0) return;
        Act();
    }
    public override void Act()
    {
        Attack();
        CounterAttack();
    }

    public void Attack()
    {
        Vector2 botLeft = (Vector2)transform.position + pointA;
        Vector2 topRight = (Vector2)transform.position + pointB;
        Collider2D playerCollider = Physics2D.OverlapArea(botLeft ,
            topRight, playerMask);

        if(playerCollider != null)
        {
            FlipEnemy();

            isAttacking = true;

            timerToFire -= Time.deltaTime;

            if(timerToFire <= 0)
            {
                //EnemyCtrl.Instance.EnemyAnimations.AttackState();
                transform.GetComponent<EnemyAnimations>().AttackState();

                GameObject bulletSlime = Instantiate(enemyBullet, transform.position, Quaternion.identity);

                PlayerCtrl.Instance.PlayerHeath.TakeDamage(dameToPlayer);

                timerToFire = timeBwFire;
            }
            
        }
        else
        {
            isAttacking = false;
        }
    }

    public void CounterAttack()
    {
        if(!transform.GetComponent<EnemyCtrl>().EnemyHeath.isCounterAttack) { return; }

        FlipEnemy();

        timerToFire -= Time.deltaTime;

        if (timerToFire <= 0)
        {
            //EnemyCtrl.Instance.EnemyAnimations.AttackState();
            transform.GetComponent<EnemyAnimations>().AttackState();

            GameObject bulletSlime = Instantiate(enemyBullet, transform.position, Quaternion.identity);

            PlayerCtrl.Instance.PlayerHeath.TakeDamage(dameToPlayer);

            timerToFire = timeBwFire;
        }
    }

    public void FlipEnemy()
    {
        if(transform.position.x >= PlayerCtrl.Instance.transform.position.x) 
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector2 botLeft = (Vector2)transform.position + pointA;
        Vector2 topRight = (Vector2)transform.position + pointB;

        Gizmos.DrawLine(botLeft , new Vector2(botLeft.x , topRight.y )); // cạnh trái
        Gizmos.DrawLine(topRight , new Vector2(botLeft.x , topRight.y ));  // cạnh trên
        Gizmos.DrawLine(botLeft , new Vector2(topRight.x , botLeft.y )); // cạnh dưới
        Gizmos.DrawLine(topRight , new Vector2(topRight.x, botLeft.y )); // cạnh phải
    }
}
