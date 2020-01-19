using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngrenagemDireita : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 15.0f;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 5.0f), velocidadeRotacao * Time.deltaTime);
    }
}
