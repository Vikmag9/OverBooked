using UnityEngine;

public class KeyChain : MonoBehaviour
{
    public Transform pivotPoint; // Punkt att rotera kring
    public float rotationAngle = 30f; // Maximal rotationsvinkel
    public float rotationSpeed = 2f; // Rotationshastighet
    public float swingDuration = 3f; // Varaktigheten av gungning

    private float elapsedTime = 0f;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    void Start()
    {
        originalRotation = transform.localRotation;
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (elapsedTime < swingDuration)
        {
            // Beräkna rotationsvinkeln med hjälp av sinusfunktionen
            float rotationAmount = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;

            // Skapa en rotationskvaternion baserad på den beräknade rotationsvinkeln
            Quaternion rotation = Quaternion.AngleAxis(rotationAmount, Vector3.forward);

            // Applicera rotationen runt pivotpunkten
            transform.localRotation = originalRotation * rotation;
            transform.position = pivotPoint.position;

            elapsedTime += Time.deltaTime;
        }
        else
        {
            // Återställ till ursprunglig position och rotation när pendlingen är klar
            transform.localRotation = originalRotation;
            transform.localPosition = originalPosition;
        }
    }
}
