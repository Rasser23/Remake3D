using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalCollectibles = 7;
    private int collectedCount = 0;

    public TMP_Text counterText;

    public void AddCollectible()
    {
        collectedCount++;
        counterText.text = collectedCount + " / " + totalCollectibles;

        if (collectedCount >= totalCollectibles)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
