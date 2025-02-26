using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPC Dialogue" , fileName = "NPCDialogue")]
public class NpcDialog : ScriptableObject
{
    [Header("Info")]
    public string nameNPC;
    public Sprite spriteNPC;

    [Header("Interaction")]
    public bool hasInteraction;
    public  InteracionType interacionType;

    [Header("Dialogue")]

    [TextArea] public string[] dialogue;
}

public enum InteracionType
{
    Shop,
    Quest
}
