using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    public Camera mainCamera; // Reference to your main camera
    public Transform target; // The target position to zoom into (e.g., your hotel)

    public float zoomSpeed = 1.0f; // Speed of the zoom
    public float targetFOV = 30.0f; // Target field of view when zoomed in

    bool isZooming = false;

    void Start()
    {
        // Set initial camera position and FOV
        mainCamera.fieldOfView = 90.0f; // Initial field of view (wide angle)
        mainCamera.transform.position = transform.position; // Set initial camera position to where it currently is

        // Call ZoomIn method after a delay (if needed)
        Invoke("ZoomIn", 1.0f); // Adjust the delay as needed
    }

    void Update()
    {
        if (isZooming)
        {
            // Move the camera towards the target position
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, target.position, Time.deltaTime * zoomSpeed);

            // Change FOV towards the target FOV
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

            // Check if zooming is complete (adjust the threshold as needed)
            if (Vector3.Distance(mainCamera.transform.position, target.position) < 0.1f && Mathf.Abs(mainCamera.fieldOfView - targetFOV) < 0.1f)
            {
                isZooming = false;
            }
        }
    }

    void ZoomIn()
    {
        isZooming = true;
    }
}
