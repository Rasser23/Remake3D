using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public int totalCollectibles = 7; // sets the totalt number of collectibles in the game 
    private int collectedCount = 0; // how many colletibles the player has picked up 

    public TMP_Text counterText; // UI text that displays the number of collectibles picked up 

    public void AddCollectible()
    {
        collectedCount++; // increase the collectibles count 
        counterText.text = collectedCount + " / " + totalCollectibles; // update the UI text so player can see the collection progress 

        if (collectedCount >= totalCollectibles) // if all the collectibles have been collected, trigger win state
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene"); // load the WinScene
    }
}
