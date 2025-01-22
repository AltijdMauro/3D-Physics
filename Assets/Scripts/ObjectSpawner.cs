using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn1;  
    public GameObject objectToSpawn2;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnObject(objectToSpawn1);
        }
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
