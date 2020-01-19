using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private ArtificialInteligence IA;
    private Rigidbody rb;
    public int direction = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        IA = GameObject.FindWithTag("Player").GetComponent<ArtificialInteligence>();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        if(direction == 0)
        {
            rb.AddForce(Vector3.up);
        }
        if (direction == 1)
        {
            rb.AddForce(Vector3.right);
        }
        if (direction == 2)
        {
            rb.AddForce(Vector3.down);
        }
        if (direction == 3)
        {
            rb.AddForce(Vector3.left);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
