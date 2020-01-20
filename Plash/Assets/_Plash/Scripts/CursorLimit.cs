using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLimit : MonoBehaviour
{
    /// <summary>
    /// Script Para Limitar até onde o Cursor vai.
    /// </summary>
    [SerializeField]
    private float LimitTop = 0f, LimitBot = 0f, LimitLeft = 0f, LimitRight = 0f;
    [SerializeField]
    private Camera cam;


    void Update()
    {
        if (transform.position.x < LimitTop)
            transform.position = new Vector3(LimitTop ,transform.position.y,transform.position.z);
        if(transform.position.x > LimitBot)
            transform.position = new Vector3(LimitBot , transform.position.y, transform.position.z);
        if (transform.position.z < LimitLeft)
            transform.position = new Vector3(transform.position.x, transform.position.y, LimitLeft);
        if (transform.position.z > LimitRight)
            transform.position = new Vector3(transform.position.x, transform.position.y, LimitRight);
    }
}
