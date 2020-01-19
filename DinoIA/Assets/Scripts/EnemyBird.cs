using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    public float speed = 1.5f;
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
