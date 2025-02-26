using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyPatrol enemyPatrol;
    [SerializeField] private EnemyAnimations enemyAnimations;
    [SerializeField] protected EnemyHeath enemyHeath;

    public EnemyAnimations EnemyAnimations => enemyAnimations;
    public EnemyHeath EnemyHeath => enemyHeath;


    // public static EnemyCtrl Instance;
    protected virtual void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        enemyPatrol = GetComponent<EnemyPatrol>();
        enemyAnimations = GetComponent<EnemyAnimations>();
        enemyHeath = GetComponent<EnemyHeath>();

        //Instance = this;
    }

    protected virtual void Update()
    {
        if (!enemyAttack.IsAttacking && !enemyHeath.isCounterAttack)
        {
            enemyPatrol.Act();
        }
    }
}
