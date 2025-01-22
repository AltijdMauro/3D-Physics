using UnityEngine;

public class DeleteObjectOnClick : MonoBehaviour
{
    private Rigidbody rb;  // De Rigidbody van het object
    private bool isSelected = false;  // Flag om te controleren of het object geselecteerd is

    void Start()
    {
        // Haal de Rigidbody component op bij starten
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Controleer of de speler de toets '3' indrukt en het object geselecteerd is
        if (Input.GetKeyDown(KeyCode.Alpha3) && isSelected)
        {
            DeleteObject();  // Verwijder het object
        }
    }

    // Functie om het object te verwijderen
    void DeleteObject()
    {
        if (rb != null)
        {
            Destroy(gameObject);  // Verwijder het object uit de scène
        }
    }

    // Functie die wordt aangeroepen wanneer je op het object klikt
    void OnMouseDown()
    {
        // Controleer of het object een Rigidbody heeft
        if (rb != null)
        {
            isSelected = true;  // Stel het object in als geselecteerd
            Debug.Log(gameObject.name + " is geselecteerd! Druk op '3' om het te verwijderen.");
        }
    }

    // Functie die wordt aangeroepen wanneer je de muisknop loslaat (optioneel)
    void OnMouseUp()
    {
        // Deselecteer het object wanneer de muisknop losgelaten wordt
        isSelected = false;
        Debug.Log(gameObject.name + " is niet meer geselecteerd.");
    }
}
