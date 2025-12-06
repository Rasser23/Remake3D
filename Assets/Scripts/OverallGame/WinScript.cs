using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{


    public void Start()
    {
        Cursor.lockState = CursorLockMode.None; // remove the cursor lock state 
        Cursor.visible = true; // make the cursor visible 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene"); // load the StartScene
    }


}
