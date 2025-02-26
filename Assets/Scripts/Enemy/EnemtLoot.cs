using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemtLoot : MonoBehaviour
{
    
    [SerializeField] private GameObject itemPrefep;
    [SerializeField] private InventoryItems[] dropItems;

    public void DropItem()
    {
        for(int i = 0; i < dropItems.Length; i++)
        {
            int chance = Random.Range(1, 101);
            if(chance <= dropItems[i].dropChance)
            {
                GameObject itemDrop = Instantiate(itemPrefep , transform.position , Quaternion.identity);

                itemDrop.GetComponent<SpriteRenderer>().sprite = dropItems[i].iconItem;

                itemDrop.GetComponent<ItemDisplay>().item = dropItems[i];
            }
        }
    }
}


