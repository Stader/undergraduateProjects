using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOil : MonoBehaviour
{
    public GameObject [] spawn;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (animator.GetBool("Abrir"))
                    animator.SetBool("Abrir", false);
                else
                    animator.SetBool("Abrir", true);
            }
    }
    public void ReduceOil()
    {
        foreach(GameObject gameObject in spawn)
        {
            gameObject.GetComponent<SpawnOil>().size -= 0.1f;
        }
    }

    public void ReduceTotal()
    {
        foreach (GameObject gameObject in spawn)
        {
            gameObject.GetComponent<SpawnOil>().size = 0.0f;
        }
    }

    public void IncrenseOil()
    {
        foreach (GameObject gameObject in spawn)
        {
            gameObject.GetComponent<SpawnOil>().size += 0.1f;
        }
    }

    public void IncrenseTotal()
    {
        foreach (GameObject gameObject in spawn)
        {
            gameObject.GetComponent<SpawnOil>().size = 0.7f;
        }
    }
}
