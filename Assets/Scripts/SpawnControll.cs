using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{
    public static int CanSpawn = 0;

    private void OnTriggerEnter(Collider other)
    {
        CanSpawn = 1;
    }

}
