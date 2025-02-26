using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] public EnemyCtrl enemyCtrl;
    [SerializeField] public float dameAmount;
    [SerializeField] private float skillSpeed;

    private void Update()
    {
        FlyToEnemy();
    }
    //private void OnEnable()
    //{
    //    SelectionManage.OnEnemySelectedEvent += EnemySelectedCallBack;
    //    SelectionManage.OnNoSelectionEvent += NoSelectionCallBack;
    //}

    //private void OnDisable()
    //{
    //    SelectionManage.OnEnemySelectedEvent -= EnemySelectedCallBack;
    //    SelectionManage.OnNoSelectionEvent -= NoSelectionCallBack;
    //}

    //private void EnemySelectedCallBack(EnemyCtrl enemyCtrlSelection)
    //{
    //    enemyCtrl = enemyCtrlSelection;
    //}
    //private void NoSelectionCallBack()
    //{
    //    enemyCtrl = null;
    //}

    public void FlyToEnemy()
    {
        if(enemyCtrl == null) return;

        Vector2 direction = (enemyCtrl.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

        if(transform.name == "Water Tornado(Clone)")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }     
        transform.position = Vector2.MoveTowards(transform.position , enemyCtrl.transform.position 
            , skillSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && other.GetComponent<EnemyCtrl>() == enemyCtrl)
        {
            other.GetComponent<EnemyHeath>().TakeDamage(dameAmount);
            Destroy(gameObject);

        }
    }


}
