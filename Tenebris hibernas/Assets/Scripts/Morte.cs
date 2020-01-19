using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour
{
    private new CameraFollow camera;
    private MoverPlayer player;
    private LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindWithTag("Player").GetComponent<MoverPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(Morreu());
    }

    public void AtivarMorreuEspeto()
    {
        StartCoroutine(MorreuEspeto());
    }

    IEnumerator Morreu()
    {
        camera.follow = false;
        yield return new WaitForSeconds(1.0f);
        levelChanger.FadeToLevelDie();
    }

    IEnumerator MorreuEspeto()
    {
        camera.follow = false;
        levelChanger.FadeToLevelDie();
        yield return new WaitForSeconds(0.0f);
    }
}
