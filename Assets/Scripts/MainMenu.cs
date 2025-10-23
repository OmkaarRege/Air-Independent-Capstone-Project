using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
