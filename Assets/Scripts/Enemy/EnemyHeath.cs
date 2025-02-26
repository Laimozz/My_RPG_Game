using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyHeath : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStatsSO enemyStatsSO;
    [SerializeField] public EnemyStats enemyStats;
    private Vector3 pos;

    public bool isCounterAttack;

    private void Awake()
    {
        pos = transform.position;
        enemyStats = new EnemyStats(enemyStatsSO);
    }
    public virtual void TakeDamage(float dame)
    {
        isCounterAttack = true;

        enemyStats.hpEnemy -= dame;

        DameTextManager.Instance.ShowDameText(dame , transform , Color.white);

        if(enemyStats.hpEnemy <= 0)
        {
            //Update Quest
            if(LoadQuest.Instance.questCurrent.typeQuest == TypeQuest.FightEnemy)
            {
                if(LoadQuest.Instance.questCurrent.nameQuest == enemyStats.nameEnemy)
                {
                    LoadQuest.Instance.IncrementProgress();
                }
            }

            transform.GetComponent<EnemtLoot>().DropItem();
            enemyStats.hpEnemy = 0;
            PlayerCtrl.Instance.PlayerExp.AddExp(enemyStats.dropExp);
            EnemySpawn.Instance.Spawner(pos , enemyStats.nameEnemy);
            Dead();
        }

        enemyStats.hpEnemy = Mathf.Ceil(enemyStats.hpEnemy);
    }

    public virtual void Dead()
    {
        //EnemyCtrl.Instance.EnemyAnimations.DeadState();
        transform.GetComponent<EnemyAnimations>().DeadState();
        Destroy(gameObject , 0.5f);
    }
}
