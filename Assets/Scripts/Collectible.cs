using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectible : MonoBehaviour
{

    public GameObject pickupText;
    private bool playerIsNear = false;

    private void Start()
    {
        if(pickupText !=null)
            pickupText.SetActive(false);
    }

    void Update()
    {
        if(playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            if(pickupText != null)
                pickupText.SetActive(false);

            FindObjectOfType<GameManager>().AddCollectible();
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            if (pickupText != null)
                pickupText.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            if (pickupText != null)
                pickupText.SetActive(false);
        }
    }

}
