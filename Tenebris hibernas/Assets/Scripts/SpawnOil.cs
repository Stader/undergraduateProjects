using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOil : MonoBehaviour
{
    public GameObject oil;
    private GameObject newObject;
    public float size = 1.0f;
    public float delay = 0.1f;
    private void Start()
    {
        StartCoroutine(SpawnNow());
    }

    IEnumerator SpawnNow()
    {
        yield return new WaitForSeconds(delay);
        if(size != 0.0f)
        {
            newObject = Instantiate(oil, transform.position, Quaternion.identity) as GameObject;
            newObject.transform.localScale = new Vector3(size, size, 1.0f);
            newObject.transform.parent = gameObject.transform;
        }
        StartCoroutine(SpawnNow());
    }
}
