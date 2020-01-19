using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMove : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    public float maxSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        DefineSpeed();
    }

    private void Update()
    {
        _rb.velocity = Time.deltaTime * speed * transform.forward;
        if ((transform.eulerAngles.y > 91f && transform.eulerAngles.y < 179f) ||
            (transform.eulerAngles.y < -91f && transform.eulerAngles.y > -179f) ||
            (transform.eulerAngles.y > 181f && transform.eulerAngles.y < 269f) ||
            (transform.eulerAngles.y > 271f && transform.eulerAngles.y < 359f) ||
            (transform.eulerAngles.y > 1f && transform.eulerAngles.y < 89f) ||
            (transform.eulerAngles.y > -89f && transform.eulerAngles.y < -1f))
            Destroy(gameObject);
    }

    private void DefineSpeed()
    {
        if (gameObject.name == "CarroPequeno1(Clone)" || gameObject.name == "CarroPequeno2(Clone)" ||
            gameObject.name == "CarroPequeno3(Clone)")
            maxSpeed = 340;
        else if (gameObject.name == "CarroMedio1(Clone)" || gameObject.name == "CarroMedio2(Clone)" ||
                 gameObject.name == "CarroMedio3(Clone)")
            maxSpeed = 320;
        else if (gameObject.name == "CarroGrande1(Clone)" || gameObject.name == "CarroGrande2(Clone)" ||
                 gameObject.name == "CarroGrande3(Clone)")
            maxSpeed = 280;
        else if (gameObject.name == "CarroGigante1(Clone)" || gameObject.name == "CarroGigante2(Clone)" ||
                 gameObject.name == "CarroGigante3(Clone)")
            maxSpeed = 260;

        speed = maxSpeed;
    }
}