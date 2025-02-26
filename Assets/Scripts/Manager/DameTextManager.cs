using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameTextManager : Singleton<DameTextManager>
{
   // public static DameTextManager Instance;
    [SerializeField] private DameText dameTextPrefap;

    //private void Awake()
    //{
    //    Instance = this;
    //}

    public void ShowDameText(float dame , Transform parent , Color c)
    {
        DameText dameText = Instantiate(dameTextPrefap , parent);

        dameText.transform.position += Vector3.up * 0.5f;

        dameText.AdjustDameText(dame , c);
    }
}
