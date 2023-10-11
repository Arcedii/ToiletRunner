using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyDelay = 60f; // ����� �������� ����� ������������ �������

    private void Start()
    {
        Invoke("DestroyObject", destroyDelay);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
