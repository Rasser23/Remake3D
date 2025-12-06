using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // load the MainScene
    }

    public void QuitGame()
    {
        Application.Quit(); // quit the application 
        Debug.Log("Quit Game");
    }
}
