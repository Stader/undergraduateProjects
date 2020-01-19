using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliparArvore : MonoBehaviour
{
    void Start()
    {
        if(Random.Range(0, 2)==1){
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
        }
    }
}
