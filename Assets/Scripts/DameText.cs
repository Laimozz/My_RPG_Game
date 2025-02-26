using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DameText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI dameText;

    public void AdjustDameText(float dame , Color dameTextColor)
    {
        dameText.text = $"-{dame}";
        dameText.color = dameTextColor;
    }
    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
