using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private AudioClip somDoTiro;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, gunBarrel.position, gunBarrel.rotation);
            AudioController.instancia.PlayOneShot(somDoTiro);
        }
    }
}
