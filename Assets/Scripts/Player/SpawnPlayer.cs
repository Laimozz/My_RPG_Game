using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public Transform spawnLeft;  // Điểm spawn bên trái
    public Transform spawnRight; // Điểm spawn bên phải

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Không tìm thấy Player! Hãy gán tag 'Player' cho nhân vật.");
            return;
        }

        if(SceneTransitionManager.previousScene == SceneManager.GetActiveScene().buildIndex - 1) 
        {
            player.transform.position = spawnLeft.position;
        }
        else if(SceneTransitionManager.previousScene == SceneManager.GetActiveScene().buildIndex + 1)
        {
            player.transform.position = spawnRight.position;
        }
    }
}
