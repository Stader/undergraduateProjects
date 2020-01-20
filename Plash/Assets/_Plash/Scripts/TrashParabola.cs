using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashParabola : MonoBehaviour
{
    private Rigidbody rb;
    public int directionTrash;
    public CapsuleCollider _col;
    public TypeTrash _type;
    public BoxCollider _box;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    public void AjustarColisor()
    {
        //_type = GetComponent<TypeTrash>();
        //_box.GetComponent<BoxCollider>();

        _box.enabled = false;
        _col.enabled = true;
        if (_type.type == Type.Plastico)
        {
            _col.center = new Vector3(-0.0011f, -0.088f, 0.0019f);
            _col.radius = 0.11f;
            _col.height = 0.71f;
            _col.direction = 1;
        }
        else if (_type.type == Type.Metal)
        {
            _col.center = new Vector3(-0.009f, -0.1f, 0f);
            _col.radius = 0.159f;
            _col.height = 0.687f;
            _col.direction = 1;
        }
        else if (_type.type == Type.Papel)
        {
            _col.center = new Vector3(0.0322f, 0.058f, -0.002f);
            _col.radius = 0.171f;
            _col.height = 0.508f;
            _col.direction = 2;
        }
    }

    public void LaunchTrash(int direction)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        if (direction == 0)
        {
            rb.AddForce(Vector3.up * RandHit(300, 350));
            rb.AddForce(Vector3.left * RandHit(250, 300));
            rb.AddForce(Vector3.back * RandHit(170, 190));
        }
        else if (direction == 1)
        {
            rb.AddForce(Vector3.up * RandHit(300, 350));
            rb.AddForce(Vector3.left * RandHit(250, 325));
        }
        else if (direction == 2)
        {
            rb.AddForce(Vector3.up * RandHit(300, 350));
            rb.AddForce(Vector3.left * RandHit(250, 300));
            rb.AddForce(Vector3.forward * RandHit(175, 200));
        }
    }

    public float RandHit(float min, float max)
    {
        float hit = UnityEngine.Random.Range(min, max);

        return hit;
    }
}
