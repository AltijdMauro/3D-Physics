using UnityEngine;

public class DragRigidbody : MonoBehaviour
{
    public float dragSpeed = 10f; // Snelheid waarmee het object beweegt
    public float maxDistance = 100f; // Maximale afstand voor interactie

    private Camera mainCamera;
    private Rigidbody selectedRigidbody;
    private Vector3 offset;
    private float objectDistance;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Linkermuisknop ingedrukt
        {
            TryPickObject();
        }

        if (Input.GetMouseButtonUp(0)) // Linkermuisknop losgelaten
        {
            ReleaseObject();
        }

        if (selectedRigidbody != null)
        {
            DragObject();
        }
    }

    void TryPickObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.rigidbody != null && !hit.rigidbody.isKinematic)
            {
                selectedRigidbody = hit.rigidbody;
                offset = selectedRigidbody.worldCenterOfMass - hit.point;
                objectDistance = Vector3.Distance(mainCamera.transform.position, hit.point);
                selectedRigidbody.useGravity = false;
            }
        }
    }

    void DragObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPosition = ray.GetPoint(objectDistance);
        selectedRigidbody.velocity = (targetPosition + offset - selectedRigidbody.position) * dragSpeed;
    }

    void ReleaseObject()
    {
        if (selectedRigidbody != null)
        {
            selectedRigidbody.velocity = Vector3.zero;
            selectedRigidbody.useGravity = true;
            selectedRigidbody = null;
        }
    }
}