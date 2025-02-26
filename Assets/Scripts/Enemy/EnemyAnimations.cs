using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private readonly int attackState = Animator.StringToHash("AttackState");

    private readonly int deadState = Animator.StringToHash("DeadState");

    [SerializeField] private Animator enemyAnimations;

    [SerializeField] private GameObject enemyUI;
    private void Start()
    {
        enemyAnimations = GetComponent<Animator>();

        enemyUI = GameObject.Find("EnemyUI");
    }
    private void Update()
    {
        if(enemyUI == null)
        {
            enemyUI = GameObject.Find("EnemyUI");
        }
    }
    public void AttackState()
    {
        enemyAnimations.SetTrigger(attackState);
    }

    public void DeadState()
    {
        enemyAnimations.SetTrigger(deadState);
        enemyUI.SetActive(false);
    }
}
