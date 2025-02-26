using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] public string idItem;
    [SerializeField] public Image icon;
    [SerializeField] public Image quantityBG;
    [SerializeField] public TextMeshProUGUI quantityText;

    public float Quantity { get; set; }

    [SerializeField] public InventoryItems itemInSlot;

    public int indexSlot;

    [SerializeField] public static int pressItem = -1;
    public void Update()
    {
        SetQuantityText();

        if (Quantity <= 0 && itemInSlot != null)
        {
            idItem = "";
            //icon.sprite = null;
            //Color iconColor = icon.color;
            //iconColor.a = 0f;
            //icon.color = iconColor;
            //quantityBG.gameObject.SetActive(false);
            ShowInventorySlot();
            itemInSlot = null;
            InventoryScript.Instance.description.SetActive(false);
        }
    }
    public void ShowInventorySlot()
    {
        icon.sprite = null;
        Color iconColor = icon.color;
        iconColor.a = 0f;
        icon.color = iconColor;
        quantityBG.gameObject.SetActive(false);
    }

    public void SetQuantityText()
    {
        quantityText.text = Quantity.ToString();
    }

    public void Description()
    {
        if(itemInSlot != null)
        {
            pressItem  = indexSlot;

            InventoryScript.Instance.description.SetActive(true);
            InventoryScript.Instance.iconDescription.sprite = itemInSlot.iconItem;
            InventoryScript.Instance.nameDescription.text = itemInSlot.nameItem;
            InventoryScript.Instance.levelRequirement.text = $"Lv{itemInSlot.levelNeeded}";
            InventoryScript.Instance.descriptionText.text = itemInSlot.descriptionItem;
        }
        else
        {
            pressItem = -1;

            InventoryScript.Instance.description.SetActive(false);
        }
        
    }
}
