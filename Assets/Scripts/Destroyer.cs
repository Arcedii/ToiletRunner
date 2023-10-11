using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyDelay = 60f; // Время задержки перед уничтожением объекта

    private void Start()
    {
        Invoke("DestroyObject", destroyDelay);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
