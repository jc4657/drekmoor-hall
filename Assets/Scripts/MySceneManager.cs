using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static void LoadDeath()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("DeathScreen");
    }

    public static void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public static void LoadWin()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("TestPass");
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
