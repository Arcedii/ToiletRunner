using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{
    public Transform prefabTransform; // Ссылка на трансформ Prefab

    private Vector3 initialPlayerPosition;
    private Vector3 initialPrefabPosition;
    private Vector3 positionOffset;

    private void Start()
    {
        initialPlayerPosition = transform.position;
        initialPrefabPosition = prefabTransform.position;
        positionOffset = initialPlayerPosition - initialPrefabPosition;
    }

    private void Update()
    {
        if (prefabTransform != null)
        {
            // Обновляем позицию Player на основе позиции Prefab и смещения
            transform.position = prefabTransform.position + positionOffset;
        }
    }
}



