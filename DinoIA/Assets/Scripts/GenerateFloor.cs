using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    public GameObject floor;
    private bool canCreateFloor;
    private void Start()
    {
        canCreateFloor = true;
        gameObject.name = "Floor";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dino"))
        {
            CreateFloor();
        }
    }

    private void CreateFloor()
    {
        if (canCreateFloor)
        {
            canCreateFloor = false;
            var pos = transform.position + new Vector3(12.16f, 0f, 0f);
            Instantiate(floor, pos, Quaternion.identity);
            Destroy(gameObject, 3f);
        }
    }
}
