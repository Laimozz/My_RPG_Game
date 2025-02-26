using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestProgress : MonoBehaviour
{
    public QuestSO quest;

    [SerializeField] private TextMeshProUGUI questDescription;

    [SerializeField] private TextMeshProUGUI[] rewards;

    [SerializeField] private TextMeshProUGUI questProgress;


    private void Update()
    {
        if (quest == null) return;
        if (quest.questCurrent == 0 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (quest.typeQuest == TypeQuest.UpLevel)
            {
                quest.questCurrent = PlayerCtrl.Instance.PlayerStats.level;
            }
        }

        questProgress.text = $"{quest.questCurrent} / {quest.questGoal}";
    }

    public void SetQuest()
    {
        if (quest != null)
        {
            questDescription.text = quest.questDescription;

            for (int i = 0; i < quest.rewards.Length; i++)
            {
                rewards[i].text = quest.rewards[i].description;
            }

            for (int i = quest.rewards.Length; i < rewards.Length; i++)
            {
                rewards[i].text = "";
            }
        }
    }
}
