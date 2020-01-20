using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpMiss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash")) return;
        Debug.Log("Miss!");
        Destroy(other.gameObject);
        
    }
}
