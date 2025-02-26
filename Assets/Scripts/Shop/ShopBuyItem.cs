using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ShopBuyItem : Singleton<ShopBuyItem>
{
    [SerializeField] private GameObject quantityPanel; // Panel nhập số lượng
    [SerializeField] private TMP_InputField quantityInput; // Ô nhập số lượng
    public InventoryItems item;

    private void Start()
    {
        quantityPanel.SetActive(false); // Ẩn panel nhập số lượng lúc đầu
    }

    public void OnBuyButtonClick()
    {
        if (item == null) return;
        quantityPanel.SetActive(true);
    }

    public void ConfirmPurchase()
    {
        if (quantityInput.text != "")
        {
            int quantity = int.Parse(quantityInput.text);
            float totalCost = quantity * item.price;

            if (InventoryScript.Instance.PlayerCoin.coin >= totalCost)
            {
                InventoryScript.Instance.PlayerCoin.coin -= totalCost;
                InventoryScript.Instance.UpdateCoin();
                InventoryScript.Instance.AddItem(item, quantity);
                Debug.Log("Mua thành công {quantity} món hàng!");
            }
            else
            {
                Debug.Log("Không đủ xu để mua!");
            }

            CloseQuantityPanel();
        }
    }

    public void CloseQuantityPanel()
    {
        quantityPanel.SetActive(false);
        quantityInput.text = ""; // Reset số lượng về 0
    }
}

