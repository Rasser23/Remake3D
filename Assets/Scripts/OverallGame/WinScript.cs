using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{


    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }


}
