using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStench : MonoBehaviour
{
    void Start()
    {
        if (transform.position.y > 2.9f || transform.position.y < -1.2f || transform.position.x < -0.2f || transform.position.x > 3.2f)
        {
            Destroy(gameObject);
        }
    }

}
