using UnityEngine;

public class KeyChain : MonoBehaviour
{
    public Transform pivotPoint; // Punkt att rotera kring
    public float rotationAngle = 30f; // Maximal rotationsvinkel
    public float rotationSpeed = 2f; // Rotationshastighet

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        // Beräkna rotationsvinkeln med hjälp av sinusfunktionen
        float rotationAmount = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;

        // Skapa en rotationskvaternion baserad på den beräknade rotationsvinkeln
        Quaternion rotation = Quaternion.AngleAxis(rotationAmount, Vector3.forward);

        // Applicera rotationen runt pivotpunkten
        transform.localRotation = originalRotation * rotation;
        transform.position = pivotPoint.position;
    }
}
