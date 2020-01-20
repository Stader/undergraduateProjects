using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dump : MonoBehaviour
{
    /*
     Papel, Plastico, Vidro
     Metal, Hospitalar, Radioativo
     Hospitalar, Plastico, Papel
     */
    private ScoreGame score;
    public Type typeDump;
    [SerializeField] private AudioSource hitSound;

    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        score = GameObject.Find("Canvas").GetComponent<ScoreGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash")) return;

        if (other.GetComponent<TypeTrash>().type != typeDump)
        {
            Destroy(other.gameObject);
            return;
        }
        Destroy(other.gameObject);
        score.UpdateScore();
        hitSound.Play();
    }
}
