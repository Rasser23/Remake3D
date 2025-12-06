using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectible : MonoBehaviour // this script handles the logic of the collectibles 
{

    public GameObject pickupText; // UI text shown when player is close to object 
    private bool playerIsNear = false; // tracks whether the player is in distance of pick up 

    private void Start()
    {
        if(pickupText !=null) // hide the pick up text at the start if it exists 
            pickupText.SetActive(false);
    }

    void Update()
    {
        if(playerIsNear && Input.GetKeyDown(KeyCode.E)) // if the player is close enough and presses E 
        {
            // hide the text before destroying the object 
            if(pickupText != null) 
                pickupText.SetActive(false);

            FindObjectOfType<GameManager>().AddCollectible(); // tell the gamemanager that an collectible has been collected
            
            Destroy(gameObject); // remove the gameobject from the scene 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // when something enters the trigger area, check the tag 
        {
            playerIsNear = true; // player is in range 
            if (pickupText != null) // show the UI pick up text 
                pickupText.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // when the player leaves the trigger area 
        {
            playerIsNear = false; // player is out of range 
            if (pickupText != null) // hide the UI pickup text 
                pickupText.SetActive(false);
        }
    }

}
