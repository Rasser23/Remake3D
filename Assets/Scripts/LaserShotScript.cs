using UnityEngine;
using System.Collections;
public class LaserShotScript : MonoBehaviour

{
    public float shootDistance = 50f;
    public float laserTime = 0.01f;
    public LineRenderer line;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        if (line != null)
        {
            line.enabled = false;
        }
    }

    private void Update()
    {  
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (line == null || cam == null) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        Vector3 endPoint;

        if (Physics.Raycast(ray, out hit, shootDistance))
        {
            endPoint = hit.point;

            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }    
        }

        else
        {
            endPoint = cam.transform.position + cam.transform.forward * shootDistance;
        }

        StartCoroutine(ShowLaser(endPoint));
    }

    private IEnumerator ShowLaser(Vector3 endPoint)
    {
        
        Vector3 startPoint = cam.transform.position + cam.transform.forward * 1f;
        
        line.SetPosition(0, cam.transform.position);
        line.SetPosition(1, endPoint);

        line.enabled = true;
        yield return new WaitForSeconds(laserTime);
        line.enabled = false;
    
    }


}