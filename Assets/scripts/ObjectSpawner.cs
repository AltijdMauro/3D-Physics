using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn1;  // Het object dat spawnt bij input '1'
    public GameObject objectToSpawn2;  // Het object dat spawnt bij input '2'
    public Transform spawnPoint;       // De locatie waar de objecten spawnen

    void Update()
    {
        // Controleren of de speler '1' heeft ingedrukt
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnObject(objectToSpawn1);
        }

        // Controleren of de speler '2' heeft ingedrukt
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnObject(objectToSpawn2);
        }
    }

    // Functie om het object te spawnen
    void SpawnObject(GameObject objectToSpawn)
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("ObjectToSpawn or SpawnPoint is not assigned!");
        }
    }
}
