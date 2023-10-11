using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoordinate : MonoBehaviour
{
    public Vector3 targetPosition; // Целевые координаты объекта

    private void Start()
    {
        transform.position = targetPosition; // Устанавливаем начальные координаты объекта
    }
}
