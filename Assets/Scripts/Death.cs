using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Death");
        DeathController.Controller = 1;
        Time.timeScale = 0f;
    }

    
}
