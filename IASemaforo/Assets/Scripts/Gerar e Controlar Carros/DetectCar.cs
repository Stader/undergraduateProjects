using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCar : MonoBehaviour
{
    private CarroMove _move;
    private Color _orange = new Color(255f, 165f, 0f, 1f);

    private void Start()
    {
        _move = GetComponent<CarroMove>();
    }

    private void Update()
    {
        RaycastHit hit;
        var layerMask = 1 << 8;
        //bool grounded = (Physics.Raycast(transform.position, Vector3.forward, 5f, LayerMask.NameToLayer("layerCarro")));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.black);
            _move.speed = (_move.maxSpeed / 100) * 0;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            _move.speed = (_move.maxSpeed / 100) * 13;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.magenta);
            _move.speed = (_move.maxSpeed / 100) * 25;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, _orange);
            _move.speed = (_move.maxSpeed / 100) * 34;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
            _move.speed = (_move.maxSpeed / 100) * 45;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 6f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.green);
            _move.speed = (_move.maxSpeed / 100) * 57;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
            _move.speed = (_move.maxSpeed / 100) * 68;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 8f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            _move.speed = (_move.maxSpeed / 100) * 75;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 9f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.gray);
            _move.speed = (_move.maxSpeed / 100) * 87;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f,
            layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.grey);
            _move.speed = (_move.maxSpeed / 100) * 95;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 12, Color.white);
            _move.speed = _move.maxSpeed;
        }
    }
}