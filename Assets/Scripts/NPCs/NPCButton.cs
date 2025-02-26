using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCButton : MonoBehaviour
{
    [Header("Shop Food")]
    [SerializeField] private GameObject shopFood;
    [SerializeField] private GameObject npcFoodStart;
    [SerializeField] private GameObject shopFoodDescription;

    [Header("Shop Weapon")]
    [SerializeField] private GameObject shopWeapon;
    [SerializeField] private GameObject npcWeaponStart;
    [SerializeField] private GameObject shopWeaponDescription;

    [Header("Quest Panel")]
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject npcQuestStart;

    private void Start()
    {
        //shop food
        shopFood.SetActive(false);
        npcFoodStart.SetActive(false);

        //shop Weapon
        shopWeapon.SetActive(false);
        npcWeaponStart.SetActive(false);

        //Quest Panel
        questPanel.SetActive(false);
        npcQuestStart.SetActive(false);
    }

    // Shop Food
    public void OpenShopFood()
    {
        shopFood.SetActive(true);
        npcFoodStart.SetActive(false);
    }

    public void CloseShopFood()
    {
        shopFood.SetActive(false);
        shopFoodDescription.SetActive(false);
    }

    // Shop Weapon
    public void OpenShopWeapon()
    {
        shopWeapon.SetActive(true);
        npcWeaponStart.SetActive(false);
    }

    public void CloseShopWeapon()
    {
        shopWeapon.SetActive(false);
        shopWeaponDescription.SetActive(false);
    }

    // Quest Panel

    public void OpenQuestPanel()
    {
        questPanel.SetActive(true);
        npcQuestStart.SetActive(false);
    }

    public void CloseQuestPanel()
    {
        questPanel.SetActive(false);
    }
}
