using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuest : Singleton<LoadQuest>
{
    [SerializeField] private AllQuest allQuest;
    [SerializeField] private GameObject questReceived;
    [SerializeField] public QuestSO questCurrent;

    private readonly string QUEST_KEY_DATA = "My_Quest";

    public QuestSO ExistQuestInGame(string id)
    {
        for (int i = 0; i < allQuest.allQuest.Length; i++)
        {
            if (allQuest.allQuest[i].questID == id)
            {
                return allQuest.allQuest[i];
            }
        }
        return null;
    }
    //Load Quest Scene
    private void Start()
    {
        if (SaveGame.Exists(QUEST_KEY_DATA))
        {
            QuestData loadData = SaveGame.Load<QuestData>(QUEST_KEY_DATA);

            questCurrent = ExistQuestInGame(loadData.questID);

            if(questCurrent != null)
            {
                questReceived.SetActive(true);
                questReceived.transform.GetComponent<QuestProgress>().quest = questCurrent;
                questReceived.transform.GetComponent<QuestProgress>().SetQuest();
            }
        }
    }

    public void IncrementProgress()
    {
        questCurrent.questCurrent++;
    }
}
