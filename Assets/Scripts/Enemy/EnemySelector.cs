using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject selectorSprite;

    //[SerializeField] private GameObject enemyUI;
    //[SerializeField] private TextMeshProUGUI enemyName;
    //[SerializeField] private TextMeshProUGUI enemyLevel;
    //[SerializeField] private TextMeshProUGUI enemyHeathText;
    //[SerializeField] private Image enemyHeath;


    [SerializeField] private EnemyCtrl enemyCtrl;

    void Start()
    {
        enemyCtrl = GetComponent<EnemyCtrl>();
    }

    private void Update()
    {
        //if(enemyUI == null)
        //{
        //    enemyUI = GameObject.Find("EnemyUI");
        //    if(enemyUI != null )
        //    {
        //        enemyName = GameObject.Find("EnemyName").GetComponent<TextMeshProUGUI>();
        //        enemyLevel = GameObject.Find("EnemyLevel").GetComponent<TextMeshProUGUI>();
        //        enemyHeathText = GameObject.Find("HeathText(Enemy)").GetComponent<TextMeshProUGUI>();
        //        enemyHeath = GameObject.Find("HeathBar(Enemy)").GetComponent<Image>();
        //    }    
        //}
        //else
        //{
        //    if (enemyUI.activeSelf && selectorSprite.activeSelf)
        //    {
        //        //Debug.Log(enemyStats.hpEnemy);
        //        enemyHeathText.text = $"{enemyCtrl.EnemyHeath.enemyStats.hpEnemy} / {enemyCtrl.EnemyHeath.enemyStats.maxHpEnemy}";
        //        enemyHeath.fillAmount = Mathf.Lerp(enemyHeath.fillAmount,
        //            enemyCtrl.EnemyHeath.enemyStats.hpEnemy / enemyCtrl.EnemyHeath.enemyStats.maxHpEnemy, 10f * Time.deltaTime);

        //        enemyName.text = enemyCtrl.EnemyHeath.enemyStats.nameEnemy;
        //        enemyLevel.text = $"Level {enemyCtrl.EnemyHeath.enemyStats.levelEnemy}";
        //    }
        //}

        if (SelectionManage.Instance.enemyUI.activeSelf && selectorSprite.activeSelf)
        {
            SelectionManage.Instance.enemyHeathText.text = $"{enemyCtrl.EnemyHeath.enemyStats.hpEnemy} / {enemyCtrl.EnemyHeath.enemyStats.maxHpEnemy}";
            SelectionManage.Instance.enemyHeath.fillAmount = Mathf.Lerp(SelectionManage.Instance.enemyHeath.fillAmount,
                enemyCtrl.EnemyHeath.enemyStats.hpEnemy / enemyCtrl.EnemyHeath.enemyStats.maxHpEnemy, 10f * Time.deltaTime);

            SelectionManage.Instance.enemyName.text = enemyCtrl.EnemyHeath.enemyStats.nameEnemy;
            SelectionManage.Instance.enemyLevel.text = $"Level {enemyCtrl.EnemyHeath.enemyStats.levelEnemy}";
        }
    }
    private void OnEnable()
    {
        SelectionManage.OnEnemySelectedEvent += EnemySelectedCallBack;
        SelectionManage.OnNoSelectionEvent += NoSelectionCallBack;
    }

    private void OnDisable()
    {
        SelectionManage.OnEnemySelectedEvent -= EnemySelectedCallBack;
        SelectionManage.OnNoSelectionEvent -= NoSelectionCallBack;
    }

    private void EnemySelectedCallBack(EnemyCtrl enemySelected)
    {
        if (enemySelected == enemyCtrl)
        {
            selectorSprite.SetActive(true);
            SetStatsEnemy();
        }
        else
        {
              selectorSprite.SetActive(false);
        //    enemyUI.SetActive(false);
        }
    }

    private void NoSelectionCallBack()
    {
        selectorSprite.SetActive(false);
        //if(enemyUI != null)
        //{
        //    enemyUI.SetActive(false);
        //}   
        SelectionManage.Instance.enemyUI.SetActive(false);
    }

    private void SetStatsEnemy()
    {
        //if(enemyUI == null) return;

        //enemyUI.SetActive(true);

        SelectionManage.Instance.enemyUI.SetActive(true);
    }
}
