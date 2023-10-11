using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelVechickleEnable : MonoBehaviour
{
    
    public MonoBehaviour scriptToEnable; // —сылка на скрипт, который нужно отключить

    private void Start()
    {
        scriptToEnable.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        scriptToEnable.enabled = true;
    }
}
