using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 3f;
    private float originalSpeed = 3f;
    private float timer;
    private void Awake()
    {
        originalSpeed = speed;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        speed = originalSpeed + timer / 1000;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void Restore()
    {
        timer = 0;
        speed = originalSpeed;
    }
}
