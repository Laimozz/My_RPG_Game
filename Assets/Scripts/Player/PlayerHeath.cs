using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class PlayerHeath : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatsSO playerStatsSO;

    [SerializeField] private PlayerAnimations myPlayerAnimations;

    [SerializeField] private GameObject homeButton;
    private void Awake()
    {
        myPlayerAnimations = GetComponent<PlayerAnimations>();
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            homeButton.SetActive(false);
        }
        
    }

    public void TakeDamage(float dame)
    {
        dame = Mathf.Max(1, dame - playerStatsSO.protect);
        playerStatsSO.hp -= dame;
        playerStatsSO.hp = Mathf.Ceil(playerStatsSO.hp);

        DameTextManager.Instance.ShowDameText(dame, transform, Color.red);

        if (playerStatsSO.hp <= 0)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                homeButton.SetActive(true);
            }
            playerStatsSO.hp = 0;
            Dead();
        }
    }

    public void Dead()
    {
        myPlayerAnimations.DeadState();
    }

}
