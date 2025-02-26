using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    [SerializeField] private GameObject dialogueImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] NpcDialog npcDialogue;

    [SerializeField] private float dialogueDuration = 4f; // Thời gian hiển thị mỗi câu thoại
    [SerializeField] private float dialogueInterval = 6f; // Khoảng thời gian giữa các câu thoại

    [SerializeField] private int currentDialogueIndex = 0;

    [SerializeField] private float timeToNPCSpeak = 20f;
    private void Start()
    {
        dialogueImage.SetActive(false);

        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        while (true)
        {
            dialogueText.text = npcDialogue.dialogue[currentDialogueIndex];

            dialogueImage.SetActive(true);

            yield return new WaitForSeconds(dialogueDuration);
       
            dialogueImage.SetActive(false);

            if (currentDialogueIndex == npcDialogue.dialogue.Length - 1)
            {
                yield return new WaitForSeconds(timeToNPCSpeak);
            }
            else
            {
                yield return new WaitForSeconds(dialogueInterval);
            }

            currentDialogueIndex = (currentDialogueIndex + 1) % npcDialogue.dialogue.Length;
        }
    }
}
