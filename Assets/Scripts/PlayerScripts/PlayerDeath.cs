using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour // this script handles the players death when touching the spheres
{

    private void OnCollisionEnter(Collision collision) // If the player collides with gameobject with tag "Enemy" - restart the game 
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    private void OnTriggerEnter(Collider other) // same as before but fir trigger colliders
    {
        if (other.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        Scene current = SceneManager.GetActiveScene(); // get the current active scene 
        SceneManager.LoadScene(current.buildIndex); // reload the scene via build.index
    }



}
