using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarBau : MonoBehaviour
{
    public GameObject chest;
    private bool existChest = false;

    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Bau"))
            existChest = true;
        else
            existChest = false;

        if (!existChest)
        {
            Instantiate(chest, transform.position, Quaternion.identity);
            //existChest = true;
        }
    }
}
