using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : Singleton<InventoryScript>
{
    [SerializeField] private GameObject slotPrefap;

    [SerializeField] private Transform parentSlots;

    [SerializeField] private int inventorySize;

    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();

    [SerializeField] private InventoryItems itemTest;

    [Header("Coin")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI diamondText;
    [SerializeField] private PlayerCoinSO playerCoin;
    public PlayerCoinSO PlayerCoin => playerCoin;

    [Header("Description")]
    [SerializeField] public GameObject description;
    [SerializeField] public Image iconDescription;
    [SerializeField] public TextMeshProUGUI nameDescription;
    [SerializeField] public TextMeshProUGUI levelRequirement;
    [SerializeField] public TextMeshProUGUI descriptionText;


    [Header("SaveGame")]
    [SerializeField] private GameContent gameContent;
    private readonly string INVENTORY_KEY_DATA = "My_Inventory";

    private void Start()
    {
        CreateInventorySlots();
        UpdateCoin();
        LoadInventory();
        //SaveGame.Delete(INVENTORY_KEY_DATA);
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            AddItem(itemTest, 1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            for(int i= 0; i < inventorySize; i++) 
            {
                if (slots[i].idItem == "heath_potion")
                {
                    slots[i].itemInSlot.Use();
                    slots[i].Quantity -= 1;
                    SaveInventory();
                    break;
                }
            }   
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            for (int i = 0; i < inventorySize; i++)
            {
                if (slots[i].idItem == "mana_potion")
                {
                    slots[i].itemInSlot.Use();
                    slots[i].Quantity -= 1;
                    SaveInventory();
                    break;
                }
            }
        }
    }

    // khoi tao cac slot Inventory
    public void CreateInventorySlots()
    {
        for(int i = 0; i < inventorySize; i++)
        {
            GameObject slot = Instantiate(slotPrefap , parentSlots);
            slot.GetComponent<InventorySlot>().ShowInventorySlot();
            slot.GetComponent<InventorySlot>().indexSlot = i;
            slots.Add(slot.GetComponent<InventorySlot>());
        }
    }
    // Check xem Item do ton tai trong inventory hay chua 
    public List<int> CheckItemExist(InventoryItems item)
    {
        List<int> indexsItem = new List<int>();
        for(int i = 0 ; i < inventorySize; i++)
        {
            if (slots[i].idItem == item.idItem)
            {
                indexsItem.Add(i);
            }
        }

        return indexsItem;
    }
    
    // neu ton tai roi thi check xem no co stack duoc khong
    public bool IsStackItem(InventoryItems item)
    {
        return item.isStack;
    }

    // Them Item vao trong inventory va so luong

    public void AddItem(InventoryItems item , float amount)
    {
        List<int> index = CheckItemExist(item);
        if(IsStackItem(item) && index.Count > 0 )
        {
            // so stack cho 1 item nay
            float maxStack = item.maxStack;
            // them so luong item vao nhung slot chua item nay
            foreach (int x in index)
            {
                if (slots[x].Quantity < maxStack)
                {
                    // so luong con du co them them vao
                    float quantityAvailable = maxStack - slots[x].Quantity;
                    // so sanh luong them item va luong toi da co the them item trong slot nay
                    float amountItem = Mathf.Min(amount, quantityAvailable);

                    slots[x].Quantity += amountItem;
                    slots[x].SetQuantityText();
                    amount -= amountItem;
                    if (amount <= 0) break;
                }
            }
        }
        if(amount > 0)
        {
            AddItemToEmptySlot(item , amount);
        }
        SaveInventory();
    }

    public void AddItemToEmptySlot(InventoryItems item , float amount)
    {
        for (int i = 0 ;i < inventorySize; i++)
        {
            if (slots[i].idItem == "")
            {
                float maxStack = item.maxStack;

                float amountItem = Mathf.Min(amount, maxStack);
                //slots[i].idItem = item.idItem;
                //slots[i].icon.sprite = item.iconItem;

                ////Set Color trong slot
                //Color iconColor = slots[i].icon.color;
                //iconColor.a = 1f;
                //slots[i].icon.color = iconColor;

                //slots[i].quantityBG.gameObject.SetActive(true);

                //slots[i].itemInSlot = item;
                SetInventorySlot(item, i);

                slots[i].Quantity += amountItem;
                slots[i].SetQuantityText();

                amount -= amountItem;
                if(amount <= 0) break;
            }
        }
    }

    public void ReplaceItem(InventoryItems itemReplace , int indexReplace) 
    {
        description.gameObject.SetActive(false);
        SetInventorySlot(itemReplace , indexReplace);
        slots[indexReplace].Quantity = 1;
        slots[indexReplace].SetQuantityText();

    }

    public void SetInventorySlot(InventoryItems item , int index)
    {
        slots[index].idItem = item.idItem;
        slots[index].icon.sprite = item.iconItem;

        //Set Color trong slot
        Color iconColor = slots[index].icon.color;
        iconColor.a = 1f;
        slots[index].icon.color = iconColor;

        slots[index].quantityBG.gameObject.SetActive(true);

        slots[index].itemInSlot = item;
    }

    public void SetQuantityInSlot(int index , int amount)
    {
        slots[index].Quantity -= amount;
    }
    //Use Button

    public void UseItem()
    {
        if(InventorySlot.pressItem != -1 && description.activeSelf)
        {
            if (slots[InventorySlot.pressItem].itemInSlot.isComsumable)
            {
                slots[InventorySlot.pressItem].itemInSlot.Use();
                slots[InventorySlot.pressItem].Quantity -= 1;
            }   
        }
        SaveInventory();
    }
    //Equip Button
    public void EquipItem()
    {
        if (InventorySlot.pressItem != -1 && description.activeSelf)
        {
            if (slots[InventorySlot.pressItem].itemInSlot.isEquip)
            {
                slots[InventorySlot.pressItem].itemInSlot.Equip(slots[InventorySlot.pressItem].itemInSlot, 
                    InventorySlot.pressItem);
            }
        }
        SaveInventory();
    }

    //Remove Button

    public void RemoveItem()
    {
        if (InventorySlot.pressItem != -1 && description.activeSelf)
        {
            slots[InventorySlot.pressItem].Quantity = 0;
        }
        SaveInventory();
    }

    //Save Game Data Inventory
    public void SaveInventory()
    {
        InventoryData saveData = new InventoryData();
        saveData.IDItemContent = new string[inventorySize];
        saveData.QuantityItem = new float[inventorySize];

        for(int i = 0; i < inventorySize; i++)
        {
            if (slots[i].idItem != "")
            {
                saveData.IDItemContent[i] = slots[i].idItem;
                saveData.QuantityItem[i] = slots[i].Quantity;
            }
            else
            {
                saveData.IDItemContent[i] = null;
                saveData.QuantityItem[i] = 0;
            }
        }
        SaveGame.Save(INVENTORY_KEY_DATA ,saveData);
    }
    // Load Game
    public InventoryItems ItemExistInGameContent(string id)
    {
        for(int i = 0; i < gameContent.GameItems.Length;i++)
        {
            if (gameContent.GameItems[i].idItem == id)
            {
                return gameContent.GameItems[i];
            }
        }
        return null;
    } 
    public void LoadInventory()
    {
        if (SaveGame.Exists(INVENTORY_KEY_DATA))
        {
            InventoryData loadData = SaveGame.Load<InventoryData>(INVENTORY_KEY_DATA);

            for(int i = 0; i < inventorySize; i++)
            {
                if (loadData.IDItemContent[i] != null)
                {
                    InventoryItems item = ItemExistInGameContent(loadData.IDItemContent[i]);
                    if(item != null)
                    {
                        SetInventorySlot(item, i);
                        slots[i].Quantity = loadData.QuantityItem[i];
                    }
                }
            }
        }
    }

    //coin
    public void UpdateCoin()
    {
        if (playerCoin != null)
        {
            coinText.text = $": {playerCoin.coin}";
            diamondText.text = $": {playerCoin.diamond}";
        }
    }
}
