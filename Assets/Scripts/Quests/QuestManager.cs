using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private List<QuestSO> quests = new List<QuestSO>();
    [SerializeField] private int currentQuestIndex;

    [Header("Quest Panel")]
    [SerializeField] private GameObject questSlot;

    [Header("Quest Player")]
    [SerializeField] public GameObject questReceived;


    private readonly string QUEST_KEY_DATA = "My_Quest";

    private void Start()
    {
        LoadGame();
        //SaveGame.Delete(QUEST_KEY_DATA);

        if(questSlot.transform.GetComponent<QuestSlot>().quest == null)
        {
            if (quests.Count > 0)
            {
                AssignQuest(currentQuestIndex);
            }
        }     
    }
    public void AssignQuest(int index)
    {
        if (index < quests.Count)
        {
            questSlot.SetActive(true);
            questSlot.transform.GetComponent<QuestSlot>().quest = quests[index];
            questSlot.transform.GetComponent<QuestSlot>().SetQuest();
        }
        else
        {
            questSlot.SetActive(false);
        }
    }

    public void CompleteQuest()
    {
        // Chuyển sang nhiệm vụ tiếp theo nếu có
        currentQuestIndex++;
        AssignQuest(currentQuestIndex);
    }

    //Save Game
    public void SaveQuest(bool status)
    {
        QuestData saveData = new QuestData();
        saveData.questID = quests[currentQuestIndex].questID;
        saveData.currentQuest = currentQuestIndex;
        saveData.statusQuest = status;

        SaveGame.Save(QUEST_KEY_DATA, saveData);
    }

    //Load Game
    public void LoadGame()
    {
        if (SaveGame.Exists(QUEST_KEY_DATA))
        {
            QuestData loadData = SaveGame.Load<QuestData>(QUEST_KEY_DATA);

            currentQuestIndex = loadData.currentQuest;

            questSlot.transform.GetComponent<QuestSlot>().quest = quests[currentQuestIndex];
            questSlot.transform.GetComponent<QuestSlot>().SetQuestNoSave();

            if (loadData.statusQuest)
            {
                questSlot.transform.GetComponent<QuestSlot>().ProgressQuest();

                questReceived.SetActive(true);
                questReceived.transform.GetComponent<QuestProgress>().quest = quests[currentQuestIndex];
                questReceived.transform.GetComponent<QuestProgress>().SetQuest();        
            }
        }
    }
}
