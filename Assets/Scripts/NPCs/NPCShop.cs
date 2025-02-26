using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    [SerializeField] private GameObject NPCStart;

    public void OpenCloseNPCStart()
    {
        NPCStart.SetActive(!NPCStart.activeSelf);
    }
}
