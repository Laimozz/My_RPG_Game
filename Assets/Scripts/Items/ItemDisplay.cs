using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private GameObject selectionItem;
    [SerializeField] private LayerMask itemMask;

    [SerializeField] private GameObject playerPos;
    [SerializeField] private float distanceToPickup;

    private float clickTime = 0f; // Lưu thời gian giữa hai lần click
    private float doubleClickDelay = 0.3f; // Thời gian tối đa để nhận diện Double Click

    public InventoryItems item;
    private void Start()
    {
        selectionItem.SetActive(false);

        playerPos = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Nhấn chuột trái
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, itemMask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<ItemDisplay>() == this) // Nếu nhấp vào item
            {
                if (selectionItem.activeSelf) // Nếu đã chọn trước đó, kiểm tra double click
                {
                    if (Time.time - clickTime < doubleClickDelay) // Kiểm tra khoảng cách giữa 2 lần click
                    {
                        if (Mathf.Abs(transform.position.x - playerPos.transform.position.x) <= distanceToPickup)
                        {
                            PickUpItem();
                        }

                    }
                }
                else // Nếu chọn item mới
                {
                    
                    selectionItem.SetActive(true);
                }

                clickTime = Time.time; // Cập nhật thời gian click cuối cùng
            }
            else // Nếu click ra ngoài, bỏ chọn
            {
                selectionItem.SetActive(false);
            }
        }

        // Nếu đã chọn item và nhấn Enter thì nhặt
        if (selectionItem.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            if (Mathf.Abs(transform.position.x - playerPos.transform.position.x) <= distanceToPickup)
            {
                PickUpItem();
            }
        }
    }

    public void PickUpItem()
    {
        selectionItem.SetActive(false);
        InventoryScript.Instance.AddItem(item, 1);

        Destroy(gameObject); // Hoặc thêm item vào inventory tùy vào logic của bạn   
    }
}
