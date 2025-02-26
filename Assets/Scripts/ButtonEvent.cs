using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [Header("Panel Button")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject character_Info;
    [SerializeField] private GameObject potential_Info;
    [SerializeField] private GameObject skill_Info;

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject quest;
    [SerializeField] private GameObject setting;

    [Header("Description Inventory")]
    [SerializeField] private GameObject description;


    private void Start()
    {
        panelStats.SetActive(false);

        character_Info.SetActive(false);
        potential_Info.SetActive(false);
        skill_Info.SetActive(false);
        inventory.SetActive(false);
        quest.SetActive(false);
        setting.SetActive(false);   


    }
    public void PlayerStatsButton()
    {
        panelStats.SetActive(true);
        character_Info.SetActive(true);
    }

    public void NextToPotentialInfoAndBackCharacterInfo()
    {
        potential_Info.SetActive(!potential_Info.activeSelf);
        character_Info.SetActive(!character_Info.activeSelf);
    }

    public void Exit()
    {
        character_Info.SetActive (true);
        potential_Info.SetActive(false);
        inventory.SetActive (false);

        panelStats.SetActive(false);
    }

    // Inventory
    public void InventoryState()
    {
        panelStats.SetActive (true);
        inventory.SetActive (true);

        character_Info.SetActive(false);
        potential_Info.SetActive(false);
        skill_Info.SetActive(false) ;

        description.SetActive (false);
    }

    public void NextToCharacterInfoBackToInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
        character_Info.SetActive (!character_Info.activeSelf);

        description.SetActive (false);
    }

    //Quest Player
    public void OpenCloseQuest()
    {
        quest.SetActive(!quest.activeSelf);
    }

    public void NextToSkillInfoBackToPotentialInfo()
    {
        potential_Info.SetActive(!potential_Info.activeSelf);
        skill_Info.SetActive(!skill_Info.activeSelf);
    }
    
    public void NextToInventoryBackToSkillInfo()
    {
        inventory.SetActive(!inventory.activeSelf);
        skill_Info.SetActive(!skill_Info.activeSelf);

        description.SetActive(false);
    }

    //setting
    public void OpenSetting()
    {
        setting.SetActive(!setting.activeSelf);
    }
}
