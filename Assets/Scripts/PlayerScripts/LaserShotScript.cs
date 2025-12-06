using UnityEngine;
using System.Collections;
public class LaserShotScript : MonoBehaviour // controls the laser the player can shoot with

{
    public float shootDistance = 50f; // maximum distance the laser can reach 
    public float laserTime = 0.01f; // how long the laser line is visible 
    public LineRenderer line; // reference to the LineRenderer used as the laser beam

    private Camera cam; // reference to the camera that shoots the laser 

    private void Start() 
    {
        cam = GetComponent<Camera>(); // gets the camera component on this object

        if (line != null) 
        {
            line.enabled = false; // disables the laser line at the start 
        }
    }

    private void Update()
    {  
        if (Input.GetMouseButton(0)) // if the player holds down left mouse button, then shoot
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (line == null || cam == null) return; // safety check - if lineRender or camera is missing, then stop

        Ray ray = new Ray(cam.transform.position, cam.transform.forward); // create a rey starting at the camera, and pointing forward
        RaycastHit hit;

        Vector3 endPoint; // where the laser should visually end

        if (Physics.Raycast(ray, out hit, shootDistance)) // checks if the ray hits something within the shooting range 
        {
            endPoint = hit.point; // laser endpoint becomes the hit postion 

            if (hit.collider.CompareTag("Enemy")) // if player hit an object with tag "Enemy" then destroy it
            {
                Destroy(hit.collider.gameObject);
            }    
        }

        else
        {
            endPoint = cam.transform.position + cam.transform.forward * shootDistance; // if nothing was hit, laser ends at max distance straight ahead
        }

        StartCoroutine(ShowLaser(endPoint)); // start coroutine to show laser 
    }

    private IEnumerator ShowLaser(Vector3 endPoint)
    {
        
        Vector3 startPoint = cam.transform.position + cam.transform.forward * 1f;
        
        // set lineRenderer positions: start at the camera, end a hit or miss point. 
        line.SetPosition(0, cam.transform.position); 
        line.SetPosition(1, endPoint);

        
        line.enabled = true; // turn the laser on 
        yield return new WaitForSeconds(laserTime); // keep it visible for a time 
        line.enabled = false; // turn the laser of
    
    }


}