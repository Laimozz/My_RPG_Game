using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static int previousScene = -1; // Lưu map trước đó

    public static void LoadScene(int sceneIndex)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex; // Ghi lại map hiện tại
        SceneManager.LoadScene(sceneIndex);
    }
}
