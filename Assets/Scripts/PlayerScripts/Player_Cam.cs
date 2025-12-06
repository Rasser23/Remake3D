using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Cam : MonoBehaviour // This class controls the players camera
{
    public float sensX; // Mouse sensitivity on the x-axis
    public float sensY; // Mouse sensitivity on the y-axis

    public Transform orientation; // Reference the players orientation

    float xRotation; // Stores the current x-rotation 
    float yRotation; // Stores the current y-rotation

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the curser at the screen 
        Cursor.visible = false; // Hides the curser so it is not visible when playing
    }

    private void Update()
    {
        // Reads mouse input and mulitply by sensitivity and deltaTime
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX; // Horizontal camera rotation 
        xRotation -= mouseY; // Vertical camera rotation 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Fixes the vertical rotation so the player can't look to far up or down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // Apply my rotation to the camera
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // Rotate the players orientation only horizontally 

    }
}
