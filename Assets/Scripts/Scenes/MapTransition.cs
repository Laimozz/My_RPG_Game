using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    public int targetScene; // Map muốn chuyển đến

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneTransitionManager.LoadScene(targetScene);
        }
    }
}
