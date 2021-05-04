using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject PanelMenu;

    private void Start()
    {
        PanelMenu.SetActive(false);
    }
    /// <summary>
    /// stopping time in the game
    /// </summary>
    public void StopGame()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// starting time in the game
    /// </summary>
    public void GoGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// activation / deactivation of the menu bar
    /// </summary>
    /// <param name="active"></param>
    public void PanelActive(bool active)
    {
        PanelMenu.SetActive(active);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
