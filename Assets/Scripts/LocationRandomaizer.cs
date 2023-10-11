using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationRandomaizer : MonoBehaviour
{
    public List<GameObject> objectsToRandomize; // Список объектов для размещения
    public List<Vector3> spawnPositions; // Список координат для размещения объектов

    private void Update()
    {
        if (SpawnControll.CanSpawn == 1)
        {
            SpawnObject();
            SpawnControll.CanSpawn = 0;
        }
    }

    private void SpawnObject()
    {
        int randomObjectIndex = Random.Range(0, objectsToRandomize.Count);
        GameObject objectToSpawn = objectsToRandomize[randomObjectIndex];
        int randomPositionIndex = Random.Range(0, spawnPositions.Count);
        Vector3 spawnPosition = spawnPositions[randomPositionIndex];

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}