using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Movimentar(Vector3 dir, float speed)
    {
        _rigidbody.MovePosition(_rigidbody.position + (speed * Time.deltaTime * dir.normalized));
    }

    public void Rotacionar(Vector3 dir)
    {
        var newRotation = Quaternion.LookRotation(dir);
        _rigidbody.MoveRotation(newRotation);
    }

    public void Morrer(){
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;
    }
}
