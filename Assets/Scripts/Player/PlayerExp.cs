using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStats;


    public void AddExp(float value)
    {
        
        playerStats.currentExp += value;

        while(playerStats.currentExp >= playerStats.nextLevelExp) // tính toán xem cấp độ sau khi nhận exp là bao nhiêu 
        {
            playerStats.currentExp -= playerStats.nextLevelExp;
            playerStats.currentExp = Mathf.Ceil(playerStats.currentExp);

            UpdateLevel(); // lên 1 cấp và cập nhật lại exp cho cáp tiếp theo 
        }
    }

    public void UpdateLevel()
    {
        playerStats.pointPotential += 10;
        playerStats.skillPoint += 1;

        playerStats.level++;

        float baseExp = playerStats.initialExp;

        float nextExp = baseExp * Mathf.Pow(playerStats.level , playerStats.growthRateExp);

        playerStats.nextLevelExp = Mathf.Ceil(nextExp);


        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (LoadQuest.Instance.questCurrent.typeQuest == TypeQuest.UpLevel)
            {
                LoadQuest.Instance.IncrementProgress();
            }
        }     
    }
}
