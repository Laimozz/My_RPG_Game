using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSlot : MonoBehaviour
{
    public QuestSO quest;

    [SerializeField] private TextMeshProUGUI questDescription;

    [SerializeField] private TextMeshProUGUI[] rewards;

    // button
    [SerializeField] private GameObject joinButton;
    [SerializeField] private GameObject progressButton;
    [SerializeField] private GameObject claimButton;

    private void Update()
    {
        if(quest == null) return;
        if(quest.questCurrent >= quest.questGoal)
        {
            joinButton.SetActive(false);
            progressButton.SetActive(false);
            claimButton.SetActive(true);
        }
    }
    public void SetQuest()
    {
        QuestManager.Instance.SaveQuest(false);

        SetQuestNoSave();
    }

    public void SetQuestNoSave()
    {
        joinButton.SetActive(true);
        progressButton.SetActive(false);
        claimButton.SetActive(false);

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

    public void ProgressQuest()
    {
        joinButton.SetActive(false);
        progressButton.SetActive(true);
        claimButton.SetActive(false);
    }

    //Join button
    public void JoinQuestButton()
    {
        if(quest != null)
        {
            QuestManager.Instance.SaveQuest(true);

            ProgressQuest();

            QuestManager.Instance.questReceived.SetActive (true);
            QuestManager.Instance.questReceived.transform.GetComponent<QuestProgress>().quest = quest;
            QuestManager.Instance.questReceived.transform.GetComponent<QuestProgress>().SetQuest();
        }
    }
    //claim button
    public void ClaimQuestButton()
    {
        for(int i = 0;i < quest.rewards.Length;i++)
        {
            if (quest.rewards[i].typeReward == TypeReward.Item)
            {
                InventoryScript.Instance.AddItem(quest.rewards[i].item , quest.rewards[i].quantity);
            }
            else if(quest.rewards[i].typeReward == TypeReward.Exp)
            {
                PlayerCtrl.Instance.PlayerExp.AddExp(quest.rewards[i].quantity);
            }
            else if (quest.rewards[i].typeReward == TypeReward.Coin)
            {
                InventoryScript.Instance.PlayerCoin.coin += quest.rewards[i].quantity;
                InventoryScript.Instance.UpdateCoin();
            }
            else
            {
                InventoryScript.Instance.PlayerCoin.diamond += quest.rewards[i].quantity;
                InventoryScript.Instance.UpdateCoin();
            }
        }
        QuestManager.Instance.questReceived.SetActive(false);

        QuestManager.Instance.CompleteQuest();
    }
}
