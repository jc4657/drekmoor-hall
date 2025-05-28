using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public void RetryGame()
    {
        MySceneManager.LoadGame();
    }

    public void QuitGame()
    {
        MySceneManager.QuitGame();
    }
}
