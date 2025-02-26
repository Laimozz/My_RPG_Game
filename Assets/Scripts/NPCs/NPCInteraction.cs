using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private NPCShop currentShop;

    [SerializeField] private Image buttonOpenShop;


    private void Update()
    {
        if(currentShop != null)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                currentShop.OpenCloseNPCStart(); 
            }
        }
    }
    private void Start()
    {
        buttonOpenShop.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentShop = this.GetComponent<NPCShop>();
            buttonOpenShop.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentShop = null;
            buttonOpenShop.gameObject.SetActive(false);
        }
    }
}
