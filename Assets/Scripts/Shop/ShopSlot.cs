using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private InventoryItems item;
    // Description
    [SerializeField] private GameObject description;
    [SerializeField] private Image iconDescription;
    [SerializeField] private TextMeshProUGUI nameDescription;
    [SerializeField] private TextMeshProUGUI levelRequirement;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI price;

    private void Start()
    {
        description.SetActive(false);
    }

    public void OpenDescription()
    {
        if(item != null)
        {
            description.SetActive(true);

            iconDescription.sprite = item.iconItem;
            nameDescription.text = item.name;
            levelRequirement.text = $"Lv{item.levelNeeded}";
            descriptionText.text = item.descriptionItem;
            price.text = $"Giá : {item.price} xu";

            ShopBuyItem.Instance.item = item;
        }
        else
        {
            description.SetActive(false);

            ShopBuyItem.Instance.item = null;
        }
    }
}
