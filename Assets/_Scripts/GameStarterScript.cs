using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarterScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
