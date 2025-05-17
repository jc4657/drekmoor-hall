using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static void LoadDeath()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("DeathScreen");
    }
}
