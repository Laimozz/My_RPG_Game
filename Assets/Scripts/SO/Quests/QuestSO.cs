using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quests/Quest" , fileName ="Quest")]
public class QuestSO : ScriptableObject
{
    public TypeQuest typeQuest;

    public string questID;

    public string nameQuest;

    public string unlockRequirement;

    [TextArea] public string questDescription;

    public int questCurrent;

    public int questGoal;

    public bool isComplete;

    public RewardQuest[] rewards;
}

[Serializable]
public class RewardQuest
{
    public TypeReward typeReward;
    public InventoryItems item;
    public int quantity;
    public string description;
}

public enum TypeReward
{
    Item,
    Exp,
    Coin,
    Diamond
}

public enum TypeQuest
{
     UpLevel,
     FightEnemy
}
