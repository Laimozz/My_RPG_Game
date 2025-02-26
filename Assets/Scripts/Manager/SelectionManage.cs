using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManage : Singleton<SelectionManage>
{

    public static event Action<EnemyCtrl> OnEnemySelectedEvent;
    public static event Action OnNoSelectionEvent;

    [SerializeField] private LayerMask enemyMask;

    [Header("EnemyUI")]
    [SerializeField] public GameObject enemyUI;
    [SerializeField] public TextMeshProUGUI enemyName;
    [SerializeField] public TextMeshProUGUI enemyLevel;
    [SerializeField] public TextMeshProUGUI enemyHeathText;
    [SerializeField] public Image enemyHeath;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        SelectEnemy();
    }

    public void SelectEnemy()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), 
                Vector2.zero , Mathf.Infinity , enemyMask);

            if(hit.collider != null)
            {
                EnemyCtrl enemyCtrl = hit.collider.GetComponent<EnemyCtrl>();

                if(enemyCtrl != null )
                {
                    OnEnemySelectedEvent?.Invoke(enemyCtrl);
                }
            }
            else
            {
                OnNoSelectionEvent?.Invoke();
            }
        }
    }
}
