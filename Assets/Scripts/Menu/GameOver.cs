using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
