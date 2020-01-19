using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espeto : MonoBehaviour
{
    private Morte morte;
    private void Start()
    {
        morte = GameObject.Find("LimiteMapa").GetComponent<Morte>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            morte.AtivarMorreuEspeto();
        if (collision.gameObject.CompareTag("Bau"))
            Destroy(gameObject, 1.0f);
    }
}
