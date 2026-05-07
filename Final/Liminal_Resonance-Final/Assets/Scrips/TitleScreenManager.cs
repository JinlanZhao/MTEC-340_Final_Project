using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Application.Quit();
    }
}
}